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

            var token = _jwtUtils.GenerateToken(user.UserName);

            var userDto = user.ToDto();

            return Ok(new
            {
                message = "Login successful.",
                token,
                user = userDto
            });
        }
    }
}
