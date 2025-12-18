namespace lms_auth_be.DTOs;

public class CourseDTO(int Id, int OwnerId, string Name, string Description, DateTime DateTimeCreated)
{
    public int Id { get; set; } = Id;

    public int OwnerId { get; set; } = OwnerId;

    public string Name { get; set; } = Name;

    public string Description { get; set; } = Description;

    public DateTime DateTimeCreated { get; set; } = DateTimeCreated;
}

public record CreateCourseDTO(
    string Name,
    string Description
);
