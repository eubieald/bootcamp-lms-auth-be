using lms_auth_be.Data;
using lms_auth_be.DTOs;
using lms_auth_be.Repositories;
using lms_auth_be.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lms_auth_be.Controllers;

[Route("api/[controller]")]
[Authorize(Roles ="Admin")]
[ApiController]
public class UsersController(IUsersRepo usersRepo, SaltHashUtils saltHashUtils) : ControllerBase
{
    public IUsersRepo usersRepo = usersRepo;
    private SaltHashUtils saltHashUtils = saltHashUtils;

    // GET: api/<UsersController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await usersRepo.GetAll();
        return Ok(users.Select(users => users.ToDto()));
    }

    // GET api/<UsersController>/5
    [HttpGet("{username}")]
    public async Task<IActionResult> Get(string username)
    {
        var user = await usersRepo.GetByUserName(username);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUsersDtos value)
    {
        var existingUser = await usersRepo.GetByUserName(value.Email);
        if (existingUser != null)
            return BadRequest(new { message = "Username already exists." });

        var (hash, salt) = saltHashUtils.HashPassword(value.Password);

        var user = new User
        {
            Email = value.Email,
            FirstName = value.FirstName,
            LastName = value.LastName,
            PasswordHash = hash,
            PasswordSalt = salt
        };

        // Save the user
        await usersRepo.InsertUsersAsync(user);

        return CreatedAtAction(nameof(Get), new { Email = user.Email }, user.ToDto());
    }

    // PUT api/<UsersController>/5
    [HttpPut("{username}")]
    public async Task<IActionResult> Put(string username, [FromBody] UpdateUsersDtos value)
    {
        var (hash, salt) = saltHashUtils.HashPassword(value.Password);
        var user = await usersRepo.GetByUserName(username);
        if (user == null) return NotFound();
        user.FirstName = value.FirstName;
        user.LastName = value.LastName;
        user.PasswordHash = hash;
        user.PasswordSalt = salt;
        await usersRepo.SaveUsers(user);
        return Ok(user.ToDto());
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{username}")]
    public async Task<IActionResult> Delete(string username)
    {
        var user = await usersRepo.GetByUserName(username);
        if (user == null) return NotFound();
        await usersRepo.DeleteUsers(user);
        return NoContent();
    }
}
