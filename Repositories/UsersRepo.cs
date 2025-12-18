using lms_auth_be.Data;
using lms_auth_be.DBContext;
using lms_auth_be.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.Repositories;

public class UsersRepo(DatabaseContext dbContext, DbSet<User> table) : GenericRepo<User>(dbContext, table), IUsersRepo
{
    public async Task<User?> GetByEmail(string email)
    {
        return await this.table.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task InsertUsersAsync(User user)
    {
        await this.table.AddAsync(user);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteUser(User user)
    {
        this.table.Remove(user);
        await this.dbContext.SaveChangesAsync();
    }
}


