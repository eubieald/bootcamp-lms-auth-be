using lms_auth_be.ActionFilters;
using lms_auth_be.Data;
using lms_auth_be.DTOs;
using lms_auth_be.Enums;
using lms_auth_be.Interfaces;
using lms_auth_be.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lms_auth_be.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(
    IUsersRepo usersRepo,
    IRoleManagerService roleManager,
    ISaltHashService saltHashUtils,
    IJwtService jwtUtils
) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginAuthDtos loginDto)
    {
        var user = await usersRepo.GetByEmail(loginDto.Email);
        if (user == null)
            return Unauthorized(new { message = "Invalid username or password." });

        bool isValid = saltHashUtils.VerifyPassword(loginDto.Password, user.PasswordHash, user.PasswordSalt);
        if (!isValid)
            return Unauthorized(new { message = "Invalid username or password." });

        var roles = await roleManager.GetRolesAsync(user.Id);

        var token = jwtUtils.GenerateToken(user);

        var userDto = user.ToDto(roles.Select(r => r.ToString()));

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
    [Transactional]
    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterAuthDtos registerDto,
        [FromQuery] bool admin = false,
        [FromQuery] bool teacher = false,
        [FromQuery] bool student = false
    )
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var existingUser = await usersRepo.GetByEmail(registerDto.Email);
        if (existingUser != null)
            return BadRequest(new { message = "Email already exists." });

        var (hash, salt) = saltHashUtils.HashPassword(registerDto.Password);

        var user = new User
        {
            Email = registerDto.Email.ToLower(),
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            PasswordHash = hash,
            PasswordSalt = salt,
            DateTimeCreated = DateTime.Now
        };

        await usersRepo.CreateAsync(user);

        List<string> roles = [];

        if (admin)
        {
            await roleManager.AdminRepo.CreateAsync(new Admin
            {
                User = user,
                DateTimeCreated = DateTime.Now
            });
            roles.Add(UserRoleEnums.Admin.ToString());
        }

        if (teacher)
        {
            await roleManager.TeacherRepo.CreateAsync(new Teacher
            {
                User = user,
                DateTimeCreated = DateTime.Now
            });
            roles.Add(UserRoleEnums.Teacher.ToString());
        }


        if((!admin && !teacher) || student)
        {
            await roleManager.StudentRepo.CreateAsync(new Student
            {
                User = user,
                DateTimeCreated = DateTime.Now
            });
            roles.Add(UserRoleEnums.Student.ToString());
        }

        return CreatedAtAction(nameof(Register), new { user.Email }, user.ToDto(roles));
    }
}
