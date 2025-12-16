using lms_auth_be.Data;
using lms_auth_be.DBContext;
using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.Repositories;

public class UsersRepo : IUsersRepo
{
    private DatabaseContext _dbContext;

    public UsersRepo(DatabaseContext context)
    {
        this._dbContext = context;
    }
    public async Task<List<User>> GetAll() => await this._dbContext.Users.ToListAsync();

    public async Task<User?> GetByUserName(string username)
    {
        return await this._dbContext.Users.FindAsync(username);
    }

    public async System.Threading.Tasks.Task InsertUsersAsync(User user)
    {
        await this._dbContext.Users.AddAsync(user);
        await this._dbContext.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task SaveUsers(User user)
    {
        await this._dbContext.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task DeleteUsers(User user)
    {
        this._dbContext.Users.Remove(user);
        await this._dbContext.SaveChangesAsync();
    }
}


