using System;
using System.Net;
using System.Threading.Tasks;
using Data.Model;
using Data.Model.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Parsing.ExpressionVisitors.Transformation.PredefinedTransformations;

namespace Tunder.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMatchActionRepository _matchActionRepository;

        public MatchController(IUserRepository userRepository, IMatchActionRepository matchActionRepository)
        {
            _userRepository = userRepository;
            _matchActionRepository = matchActionRepository;
        }

        public async Task<IActionResult> CreateMatchAction(string userGuid)
        {
            Guid likedUserGUid;

            if (!Guid.TryParse(userGuid, out likedUserGUid))
            {
                return BadRequest();
            }

            var likedUser = await _userRepository.GetByGuidAsync(likedUserGUid);

            if (likedUser == null)
            {
                return NotFound();
            }

            var newMatchAction = new MatchAction(null, likedUser);
            newMatchAction = await _matchActionRepository.CreateMatchActionAsync(newMatchAction);

            if (await _matchActionRepository.IsFullMatchAsync(newMatchAction))
            {
                
            }

            return Ok();
        }
    }
}