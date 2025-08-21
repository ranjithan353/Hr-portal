using HRPortal.DTOs;
using HRPortal.Models;
using HRPortal.Services;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
//this is a comment
namespace HRPortal.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var existing = await _userService.GetUserByUsernameOrMobileAsync(request.Username);
            if (existing != null)
                return BadRequest("Username or mobile already exists.");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = new User
            {
                Username = request.Username,
                MobileNumber = request.MobileNumber,
                PasswordHash = hashedPassword,
                RoleId = request.RoleId
            };

            await _userService.CreateUserAsync(newUser);
            return Ok("Registration successful.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.GetUserByUsernameOrMobileAsync(request.UsernameOrMobile);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials.");

            var token = _userService.GenerateJwtToken(user);

            return Ok(new
            {
                Token = token,
                Role = user.Role?.RoleName,
                Name = user.Username
            });
        }
    }
}
