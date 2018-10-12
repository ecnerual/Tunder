using System;
using System.Threading.Tasks;
using tunder.BusinessObject.Requests;
using tunder.Model;
using tunder.Model.Repository;

namespace tunder.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        

        public async Task<User> Register(UserDto userDto)
        {

           
           
            
            throw new NotImplementedException();
        }

        public Task<User> Login(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Logout(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> ResumeSession(byte[] authToken)
        {
            throw new System.NotImplementedException();
        }
    }
}