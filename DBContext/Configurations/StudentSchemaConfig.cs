using lms_auth_be.Data;
using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.DBContext.Configurations;

public static class StudentSchemaConfig
{
    public static ModelBuilder AddStudentSchemaConfig(this ModelBuilder modelBuilder)
    {
        // Student to User
        modelBuilder.Entity<Student>()
            .HasOne(x => x.User)
            .WithOne(x => x.Student)
            .HasForeignKey<Student>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);

        return modelBuilder;
    }
}
