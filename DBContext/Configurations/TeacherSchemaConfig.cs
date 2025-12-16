using lms_auth_be.Data;
using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.DBContext.Configurations;

public static class TeacherSchemaConfig
{
    public static ModelBuilder AddTeacherSchemaConfig(this ModelBuilder modelBuilder)
    {
        // Teacher to User
        modelBuilder.Entity<Teacher>()
            .HasOne(x => x.User)
            .WithOne(x => x.Teacher)
            .HasForeignKey<Teacher>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);

        return modelBuilder;
    }
}
