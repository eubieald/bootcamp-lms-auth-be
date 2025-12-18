using lms_auth_be.Data;
using lms_auth_be.DTOs;

namespace lms_auth_be.Mapper;

public static class CourseDtoMapper
{
    public static CourseDTO ToDTO(this Course course)
    {
        return new CourseDTO(course.Id, course.OwnerId, course.Name, course.Description, course.DateTimeCreated);
    }
}
