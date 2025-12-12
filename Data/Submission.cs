namespace lms_auth_be.Data;

public class Submission
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public Task? Task { get; set; }

    public int EnrolledCourseId { get; set; }

    public EnrolledCourse? EnrolledCourse { get; set; }

    public string Status { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string AttachedFile { get; set; } = string.Empty;

    public DateTime DateTimeCreated { get; set; }
}
