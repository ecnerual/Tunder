using Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.BusinessObject.Requests;
using Data.Model.Repository;
using Tunder.API.Controllers;
using Tunder.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Tunder.API.Tests.Controllers
{
    [TestClass]
    public class SessionControllerTest
    {
        private Mock<IAuthService> _authServiceMock;
        private Mock<IUserRepository> _userRepoMock;
        private Mock<IConfiguration> _config;

        [TestInitialize]
        public void Init()
        {
            _authServiceMock = new Mock<IAuthService>();
            _userRepoMock = new Mock<IUserRepository>();
            _config = new Mock<IConfiguration>();
        }

        #region LOGIN

        [TestMethod]
        public async Task MissingUserReturns401Async()
        {
            User user = null;

            _authServiceMock.Setup(authS => authS.Login(It.IsAny<string>(), It.IsAny<string>()))
                        .ReturnsAsync(user);

            var controller = new SessionController(_authServiceMock.Object, _userRepoMock.Object, _config.Object);


            var loginResult = await controller.Login(new LoginDto());

            Assert.IsInstanceOfType(loginResult, typeof(UnauthorizedResult));
        }

        #endregion

        #region REGISTER!

        [TestMethod]
        public async Task UserAlreadyExists()
        {
            _userRepoMock.Setup(userRepo => userRepo.UserExists(It.IsAny<string>()))
                         .ReturnsAsync(true);

            var controller = new SessionController(_authServiceMock.Object, _userRepoMock.Object, _config.Object);

            var registerResult = await controller.Register(new UserRegisterDto() { Email = "bonjourMadame" });
            Assert.IsInstanceOfType(registerResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task UserSendUpperCaseEmail()
        {
            var lowEmail = "yolo@lol.com";
            var upperEmail = "YoLo@lol.com";

            _userRepoMock.Setup(userRepo => userRepo.UserExists(lowEmail))
                         .ReturnsAsync(true);

            _userRepoMock.Setup(userRepo => userRepo.UserExists(upperEmail))
                         .ReturnsAsync(false);

            var controller = new SessionController(_authServiceMock.Object, _userRepoMock.Object, _config.Object);

            var userDto = new UserRegisterDto
            {
                Email = upperEmail
            };

            var registerResult = await controller.Register(userDto);
            Assert.IsInstanceOfType(registerResult, typeof(BadRequestResult));
        }

        #endregion
    }
}