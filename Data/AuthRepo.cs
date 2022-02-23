using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class AuthRepo : IAuthRepo
    {   
        public DataContext _context { get; }
        public AuthRepo(DataContext context)
        {
            this._context = context;
            
        }
        public Task<ServiceResponce<int>> Login(string username, string password)
        {
          throw new Exception("...");
        }

        public async Task<ServiceResponce<int>> Register(User user, string password)
        {
            ServiceResponce<int> responce = new ServiceResponce<int>();
            if(await UserExists(user.UserName)){
                responce.Success = false;
                responce.Message = "User already exists.";
                return responce;
            }
           CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PassWordHash = passwordHash;
            user.PassWordSalt = passwordSalt;


           await _context.User.AddAsync(user);
           await _context.SaveChangesAsync();
          
           responce.Data = user.Id;
           return responce;
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.User.AnyAsync(x => x.UserName.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}