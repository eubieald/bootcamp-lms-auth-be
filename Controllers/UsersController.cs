using lms_auth_be.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lms_auth_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<Users> users = new List<Users>();

        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<IEnumerable<Users>> Get()
        {
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            var user = users.FirstOrDefault(u => u.UserName == username);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] Users value)
        {
            var user = users.FirstOrDefault(u => u.UserName == value.UserName);
            if (user != null) return BadRequest(new { message = "User with supplied username already exists." });
            users.Add(new Users {
                UserName = value.UserName,
                FirstName = value.FirstName,
                LastName = value.LastName,
                PasswordHash = value.PasswordHash,
                PasswordSalt = value.PasswordSalt,
            });

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{username}")]
        public IActionResult Put(string username, [FromBody] Users value)
        {
            var user = users.FirstOrDefault(u => u.UserName == value.UserName);
            if (user == null) return NotFound();
            user.FirstName = value.FirstName;
            user.LastName = value.LastName;
            user.PasswordHash = value.PasswordHash;
            user.PasswordSalt = value.PasswordSalt;
            return Ok(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            var user = users.FirstOrDefault(u => u.UserName == username);
            if (user == null) return NotFound();
            users.Remove(user);
            return NoContent();
        }
    }
}
