using lms_auth_be.Data;
using lms_auth_be.DTOs;
using lms_auth_be.Interfaces;
using lms_auth_be.Mapper;
using lms_auth_be.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lms_auth_be.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(
    IUsersRepo usersRepo, 
    SaltHashUtils saltHashUtils, 
    JwtUtils jwtUtils
) : ControllerBase
{
    private readonly IUsersRepo usersRepo = usersRepo;
    private readonly SaltHashUtils saltHashUtils = saltHashUtils;
    private readonly JwtUtils jwtUtils = jwtUtils;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginAuthDtos loginDto)
    {
        var user = await this.usersRepo.GetByEmail(loginDto.Email);
        if (user == null)
            return Unauthorized(new { message = "Invalid username or password." });

        bool isValid = this.saltHashUtils.VerifyPassword(loginDto.Password, user.PasswordHash, user.PasswordSalt);
        if (!isValid)
            return Unauthorized(new { message = "Invalid username or password." });

        var token = jwtUtils.GenerateToken(user);

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

    [Authorize]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterAuthDtos registerDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var existingUser = await this.usersRepo.GetByEmail(registerDto.Email);
        if (existingUser != null)
            return BadRequest(new { message = "Email already exists." });

        var (hash, salt) = this.saltHashUtils.HashPassword(registerDto.Password);

        var user = new User
        {
            Email = registerDto.Email.ToLower(),
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            PasswordHash = hash,
            PasswordSalt = salt
        };

        await this.usersRepo.InsertUsersAsync(user);

        return CreatedAtAction(nameof(Register), new { user.Email }, user.ToDto());
    }
}
