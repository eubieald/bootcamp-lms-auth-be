using lms_auth_be.Data;
using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.DBContext.Configurations;

public static class AdminSchemaConfig
{
    public static ModelBuilder AddAdminSchemaConfig(this ModelBuilder modelBuilder)
    {
        // Admin to User
        modelBuilder.Entity<Admin>()
            .HasOne(x => x.User)
            .WithOne(x => x.Admin)
            .HasForeignKey<Admin>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);

        return modelBuilder;
    }
}
