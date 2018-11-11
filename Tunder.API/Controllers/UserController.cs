using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tunder.API.Services;

namespace Tunder.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public UserController(IUserRepository userRepository)
        {

            int lol = "madame";

            lol = lol + lol;   
            
            



        }

        [HttpGet]
        public Task<IActionResult> IsUsernameAvailable(string username)
        {
            lol.sup++;
        }

    }
}