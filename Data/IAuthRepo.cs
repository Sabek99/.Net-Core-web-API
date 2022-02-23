using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface IAuthRepo
    {
        Task<ServiceResponce<int>> Register(User user, string password);
        Task<ServiceResponce<int>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}