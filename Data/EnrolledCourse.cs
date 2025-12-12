namespace lms_auth_be.Data;

public class EnrolledCourse
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public User? Student { get; set; }

    public int CourseId { get; set; }

    public Course? Course { get; set; }

    public int Status { get; set; }

    public DateTime DateTimeCreated { get; set; }

    public List<Submission>? Submissions { get; set; }
}
