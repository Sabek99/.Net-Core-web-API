using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dtos.User;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;

        public AuthController(IAuthRepo authRepo)
        {
            this._authRepo = authRepo;
        }
         [HttpPost("Register")]
         public async Task<IActionResult> Register(UserRegisterDto request )
         {
             ServiceResponce<int> responce = await _authRepo.Register(
                 new User{UserName = request.UserName}, request.Password
             );
             if(!responce.Success){
                 return BadRequest(responce);
             }
             return Ok(responce);
         }
    }
}