namespace lms_auth_be.DTOs;

public record CourseDTO();

public record CreateCourseDTO(
    string Name,
    string Description
);
