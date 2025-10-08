using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.Data;

[PrimaryKey("UserName")]
public class Users
{
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public byte[]? PasswordHash { get; set; } = null;
    public byte[]? PasswordSalt { get; set; } = null;
}
