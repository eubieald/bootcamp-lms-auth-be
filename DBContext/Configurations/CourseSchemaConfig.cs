using lms_auth_be.Data;
using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.DBContext.Configurations;

public static class CourseSchemaConfig
{
    public static ModelBuilder AddCourseSchemaConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>().HasIndex(x => x.Name).IsUnique();

        // Course to User
        modelBuilder.Entity<Course>()
            .HasOne(x => x.Owner)
            .WithMany(x => x.OwnedCourses)
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        return modelBuilder;
    }
}
