namespace lms_auth_be.Data;

public class Course
{
    public int Id { get; set; }

    public int OwnerId { get; set; }

    public User? Owner { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime DateTimeCreated { get; set; }

    public List<EnrolledCourse>? Enrolled { get; set; }

    public List<Tasks>? Tasks { get; set; }
}
