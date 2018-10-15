using Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tunder.BusinessObject.Requests;
using tunder.Controllers;
using tunder.Model.Repository;
using tunder.Services;
using Microsoft.AspNetCore.Mvc;

namespace Tunder.API.Tests.Controllers
{
    [TestClass]
    public class SessionControllerTest
    {
        private Mock<IAuthService> _authServiceMock;
        private Mock<IUserRepository> _userRepoMock;

        [TestInitialize]
        public void Init()
        {
            _authServiceMock = new Mock<IAuthService>();
            _userRepoMock = new Mock<IUserRepository>();
        }

        #region Login

        [TestMethod]
        public async void MissingUserReturns401Async()
        {
            User user = null;

            _authServiceMock.Setup(authS => authS.Login(It.IsAny<string>(), It.IsAny<string>()))
                        .ReturnsAsync(user);

            var controller = new SessionController(_authServiceMock.Object, _userRepoMock.Object);


            var loginResult = await controller.Login(new LoginDto());

            Assert.IsInstanceOfType(loginResult, typeof(UnauthorizedResult));
        }

        #endregion

        #region REGISTER!

        [TestMethod]
        public async void UserAlreadyExists()
        {
            _userRepoMock.Setup(userRepo => userRepo.UserExists(It.IsAny<string>()))
                         .ReturnsAsync(true);

            var controller = new SessionController(_authServiceMock.Object, _userRepoMock.Object);

            var registerResult = await controller.Register(new UserRegisterDto());
            Assert.IsInstanceOfType(registerResult, typeof(BadRequestResult));
        }

        #endregion
    }
}