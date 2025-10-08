using lms_auth_be.DTOs;
using lms_auth_be.Repositories;
using lms_auth_be.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lms_auth_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUsersRepo usersRepo, SaltHashUtils saltHashUtils) : ControllerBase
    {
        public IUsersRepo usersRepo = usersRepo;
        private SaltHashUtils saltHashUtils = saltHashUtils;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthDtos loginDto)
        {
            // 1️⃣ Find user by username
            var user = await usersRepo.GetByUserName(loginDto.UserName);
            if (user == null)
                return Unauthorized(new { message = "Invalid username or password." });

            // 3️⃣ Verify password
            bool isValid = saltHashUtils.VerifyPassword(loginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (!isValid)
                return Unauthorized(new { message = "Invalid username or password." });

            var userDto = user.ToDto();

            return Ok(new
            {
                message = "Login successful.",
                user = userDto
            });
        }

    }
}
