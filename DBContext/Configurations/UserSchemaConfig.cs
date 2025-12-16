using lms_auth_be.Data;
using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.DBContext.Configurations;

public static class UserSchemaConfig
{
    public static ModelBuilder AddUserSchemaConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();

        return modelBuilder;
    }
}
