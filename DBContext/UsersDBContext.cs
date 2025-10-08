using Microsoft.EntityFrameworkCore;
using lms_auth_be.Data;

namespace lms_auth_be.DBContext;
public class UsersDBContext : DbContext
{
    public UsersDBContext(DbContextOptions<UsersDBContext> options) : base(options)
    {
    }

    public DbSet<Users> Users { get; set; }
}
