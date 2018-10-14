using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using tunder.BusinessObject.Requests;
using tunder.Model;

namespace tunder.Services
{
    public interface IAuthService
    {
        Task<User> Register(UserDto userDto);
        Task<User> Login(string email, string password);
        Task<User> Logout(string email, string password);
        Task<User> ResumeSession(byte[] authToken);
    }
}
