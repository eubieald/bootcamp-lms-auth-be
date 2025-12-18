using lms_auth_be.Data;
using lms_auth_be.DTOs;
using lms_auth_be.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace lms_auth_be.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(IGenericRepo<Course> courseRepo) : ControllerBase
{
    private readonly IGenericRepo<Course> courseRepo = courseRepo;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await this.courseRepo.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var entity = await this.courseRepo.GetById(id);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCourseDTO value)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.Values);

        var rawOwnerId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        if (rawOwnerId == null) return BadRequest("UserId not found");
        if (!Int32.TryParse(rawOwnerId, out int ownerId)) return BadRequest("Invalid User Id");

        // TODO - Add User Validation if exists

        var course = new Course
        {
            OwnerId = ownerId,
            Name = value.Name,
            Description = value.Description,
            DateTimeCreated = DateTime.Now,
        };

        await this.courseRepo.Create(course);

        return NoContent();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
