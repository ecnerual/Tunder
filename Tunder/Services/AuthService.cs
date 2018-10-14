using System;
using System.Threading.Tasks;
using CommonCode.Helpers;
using Data.Model;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
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
            var salt = CryptoHelpers.GetSalt();

            var hashedPassword = CryptoHelpers.HashPassword(userDto.Password, salt);

            User newUser = User.From(userDto, hashedPassword, salt);

            return await _userRepository.CreateUser(newUser);
        }

        public async Task<User> Login(string email, string password)
        {
            User user = await _userRepository.GetByEmail(email);

            return user.HashedPassword == CryptoHelpers.HashPassword(password, user.Salt) ? null : user;
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