namespace lms_auth_be.Data;

public class User
{
    // TO DO - Remove this later
    public string UserName { get; set; } = string.Empty;

    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public byte[] PasswordHash { get; set; } = [];

    public byte[] PasswordSalt { get; set; } = [];

    public DateTime DateTimeCreated { get; set; }

    public List<Course>? OwnedCourses { get; set; }

    public List<EnrolledCourse>? EnrolledCourses { get; set; }

    public Admin? Admin { get; set; }

    public Teacher? Teacher { get; set; }

    public Student? Student { get; set; }
}
