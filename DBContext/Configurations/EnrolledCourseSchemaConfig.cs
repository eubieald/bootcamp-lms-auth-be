using lms_auth_be.Data;
using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.DBContext.Configurations;

public static class EnrolledCourseSchemaConfig
{
    public static ModelBuilder AddEnrolledCourseSchemaConfig(this ModelBuilder modelBuilder)
    {
        // EnrolledCourse to Course
        modelBuilder.Entity<EnrolledCourse>()
            .HasOne(x => x.Course)
            .WithMany(x => x.Enrolled)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // EnrolledCourse to Student
        modelBuilder.Entity<EnrolledCourse>()
            .HasOne(x => x.Student)
            .WithMany(x => x.EnrolledCourses)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        return modelBuilder;
    }
}
