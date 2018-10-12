using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tunder.BusinessObject.Requests;
using tunder.Model;
using tunder.Model.Repository;
using tunder.Services;

namespace tunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public UserController(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            
        }

        
        // POST api/values
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            if (await _userRepository.UserExists(userDto.Email))
            {
                
            } 
            
            User user = await _authService.Register(userDto);
             
             

            return Ok();
        }
    }
}