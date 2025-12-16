using lms_auth_be.DTOs;
using lms_auth_be.Repositories;
using lms_auth_be.Utils;
using Microsoft.AspNetCore.Mvc;
using lms_auth_be.Enums;

namespace lms_auth_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUsersRepo usersRepo, SaltHashUtils saltHashUtils, JwtUtils jwtUtils) : ControllerBase
    {
        private readonly IUsersRepo _usersRepo = usersRepo;
        private readonly SaltHashUtils _saltHashUtils = saltHashUtils;
        private readonly JwtUtils _jwtUtils = jwtUtils;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthDtos loginDto)
        {
            var user = await _usersRepo.GetByUserName(loginDto.UserName);
            if (user == null)
                return Unauthorized(new { message = "Invalid username or password." });

            bool isValid = _saltHashUtils.VerifyPassword(loginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (!isValid)
                return Unauthorized(new { message = "Invalid username or password." });

            var token = _jwtUtils.GenerateToken(user.Email);

            var userDto = user.ToDto();

            Response.Cookies.Append("Authorization", token, new CookieOptions
            {
                HttpOnly = true, // prevents JS from reading it
                Secure = false,  // set true if using HTTPS in dev/production
                SameSite = SameSiteMode.Lax, // Lax works for dev; adjust if needed
                Expires = DateTime.UtcNow.AddHours(1)
            });

            return Ok(new
            {
                message = "Login successful.",
                user = userDto
            });
        }
    }
}
