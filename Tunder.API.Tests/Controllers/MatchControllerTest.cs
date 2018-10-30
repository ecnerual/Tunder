using System;
using System.Threading.Tasks;
using Data.BusinessObject.DTO;
using Data.Model;
using Data.Model.Enums;
using Data.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tunder.API.Controllers;

namespace Tunder.API.Tests.Controllers
{
    [TestClass]
    public class MatchControllerTest
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IMatchActionRepository> _matchActionRepositoryMock;
        private string _validGuid = Guid.NewGuid().ToString();
        private CreateMatchActionDTO _validCreateMatchActionDto;


        [TestInitialize]
        public void TestInit()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _matchActionRepositoryMock = new Mock<IMatchActionRepository>();
            _validCreateMatchActionDto = new CreateMatchActionDTO()
            {
                LikedUserGuid = _validGuid,
                MatchActionStatus = MatchActionStatus.Liked
            };
        }


        private MatchController GetTestController()
        {
            return new MatchController(_userRepositoryMock.Object, _matchActionRepositoryMock.Object);
        }


        #region CreateMatchAction
        [TestMethod]
        public async Task InvalidGuidWill_BadRequest()
        {
            var controller = GetTestController();

            _validCreateMatchActionDto.LikedUserGuid = "rip";
            var result = await controller.CreateMatchAction(_validCreateMatchActionDto);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task MissingLikedUserWill_NotFound()
        {
            User user = null;
            _userRepositoryMock.Setup(u => u.GetByGuidAsync(It.IsAny<Guid>()))
                               .ReturnsAsync(user);

            var controller = GetTestController();

            var result = await controller.CreateMatchAction(_validCreateMatchActionDto);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        #endregion
    }
}