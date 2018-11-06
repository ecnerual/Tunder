using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.BusinessObject.DTO;
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
    public class MatchController : BaseAuthController
    {
        private readonly IMatchActionRepository _matchActionRepository;
        private readonly IMatchRepository _matchRepository;


        public MatchController(IUserRepository userRepository, IMatchActionRepository matchActionRepository, IMatchRepository matchRepository) : base(userRepository)
        {
            _matchActionRepository = matchActionRepository;
            _matchRepository = matchRepository;
        }
        /*
                public async Task<IActionResult> GetUserMatches()
                {
                    var currentUser = await GetCurrentUser();


                    var matchs = (await _matchRepository.GetUserMatches(currentUser))
                                                        .OrderByDescending(m => m.MatchedSince)
                                                        .ToList();




                }

            */

        public async Task<IActionResult> CreateMatchAction(CreateMatchActionDTO createMatchActionDto)
        {
            if (!Guid.TryParse(createMatchActionDto.LikedUserGuid, out Guid likedUserGUid))
            {
                return BadRequest();
            }

            var likedUser = await _userRepository.GetByGuidAsync(likedUserGUid);

            if (likedUser == null)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUser();
            var newMatchAction = new MatchAction(currentUser, likedUser, createMatchActionDto.MatchActionStatus);

            newMatchAction = await _matchActionRepository.CreateMatchActionAsync(newMatchAction);

            if (await _matchActionRepository.IsFullMatchAsync(newMatchAction))
            {
                var newMatch = new Match()
                {

                };
                //TODO: Make a full match
                var savedMatch = await _matchRepository.CreateNewMatchAsync(newMatch);
            }

            await _matchRepository.SaveAsync();

            return Ok();
        }
    }
}