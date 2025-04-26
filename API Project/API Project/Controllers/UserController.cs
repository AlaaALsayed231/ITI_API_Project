using Bug_Ticketing.BL.DTOS.Users;
using Bug_Ticketing.BL.Managers.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManger _userManager;

        public UserController(IUserManger userManager)
        {
            _userManager = userManager;
        }

      
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
        {
            if (userDto == null) return BadRequest("Invalid user data");

            var result = await _userManager.RegisterAsync(userDto);

            if (!result) return Conflict("User already exists");

            return Ok("User registered successfully");
        }

       
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
        {
            if (userDto == null) return BadRequest("Invalid login data");

            var token = await _userManager.LogInAsync(userDto);

            if (token == null) return Unauthorized("Invalid credentials");

            return Ok(new { Token = token });
        }
    }
}
