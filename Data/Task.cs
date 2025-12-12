namespace lms_auth_be.Data;

public class Task
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public Course? Course { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Instructions { get; set; } = string.Empty;

    public DateTime Deadline { get; set; }

    public DateTime DateTimeCreated { get; set; }

    public List<Submission>? Submissions { get; set; }
}
