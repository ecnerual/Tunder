using System;
using System.Threading.Tasks;
using CommonCode.Helpers;
using Data.BusinessObject.Requests;
using Data.Model;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Data.Model.Repository;

namespace Tunder.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IThrottleService _throttleService;

        public AuthService(IUserRepository userRepository, IThrottleService throttleService)
        {
            _throttleService = throttleService ?? throw new ArgumentNullException(nameof(throttleService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<User> Register(UserRegisterDto userDto)
        {
            var salt = CryptoHelpers.GetSalt();

            var hashedPassword = CryptoHelpers.HashPassword(userDto.Password, salt);

            User newUser = User.From(userDto, hashedPassword, salt);

            await _userRepository.CreateUser(newUser);
            await _userRepository.Save();

            return newUser;
        }

        public async Task<User> Login(string email, string password)
        {
            User user = await _userRepository.GetByEmail(email);

            if (user == null || await _throttleService.GetFailLoginAttempt(user) >= 5)
            {
                return null;
            }

            var validPassword = user.HashedPassword == CryptoHelpers.HashPassword(password, user.Salt);

            if (!validPassword)
            {
                await _throttleService.LogFailLoginAttempt(user);
                return null;
            }

            return user;
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