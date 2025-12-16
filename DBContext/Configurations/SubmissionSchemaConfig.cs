using lms_auth_be.Data;
using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.DBContext.Configurations;

public static class SubmissionSchemaConfig
{
    public static ModelBuilder AddSubmissionSchemaConfig(this ModelBuilder modelBuilder)
    {
        // Submission to Task
        modelBuilder.Entity<Submission>()
            .HasOne(x => x.Task)
            .WithMany(x => x.Submissions)
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        // Submission to EnrolledCourse
        modelBuilder.Entity<Submission>()
            .HasOne(x => x.EnrolledCourse)
            .WithMany(x => x.Submissions)
            .HasForeignKey(x => x.EnrolledCourseId)
            .OnDelete(DeleteBehavior.Restrict);

        return modelBuilder;
    }
}
