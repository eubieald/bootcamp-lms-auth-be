using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.DBContext.Configurations;

public static class TaskSchemaConfig
{
    public static ModelBuilder AddTaskSchemaConfig(this ModelBuilder modelBuilder)
    {
        // Task to Course
        modelBuilder.Entity<Data.Task>()
            .HasOne(x => x.Course)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        return modelBuilder;
    }
}
