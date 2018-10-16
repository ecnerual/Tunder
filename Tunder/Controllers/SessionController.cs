using System;
using System.Threading.Tasks;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tunder.BusinessObject.Requests;
using tunder.Model.Repository;
using tunder.Services;

namespace tunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public SessionController(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpPost("register")]
        [ProducesResponseType(201, Type = typeof(User))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
        {
            if (await _userRepository.UserExists(userDto.Email.ToLower()))
            {
                BadRequest();
            }

            User user = await _authService.Register(userDto);

            return Created("user/me", user);
        }

        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            User user = await _authService.Login(loginDto.Email, loginDto.Password);

            if (user == null || !user.IsActivited)
            {
                return Unauthorized();
            }

            return Ok(user);
        }
        /*
        [HttpDelete("logout")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Logout()
        {
            //HttpContext.Request.Headers.TryGetValue();

            return NoContent();
        }
        */
    }
}