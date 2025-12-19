using lms_auth_be.Interfaces;
using lms_auth_be.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lms_auth_be.Controllers;

[Route("api/[controller]")]
[Authorize(Roles ="Admin")]
[ApiController]
public class UsersController(IUsersRepo usersRepo) : ControllerBase
{
    public readonly IUsersRepo usersRepo = usersRepo;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await usersRepo.GetAll();
        return Ok(users.Select(users => users.ToDto()));
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> Get(string username)
    {
        var user = await usersRepo.GetByEmail(username);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user.ToDto());
    }

    [HttpDelete("{username}")]
    public async Task<IActionResult> Delete(string username)
    {
        var user = await usersRepo.GetByEmail(username);
        if (user == null) return NotFound();
        await usersRepo.DeleteAsync(user);
        return NoContent();
    }
}
