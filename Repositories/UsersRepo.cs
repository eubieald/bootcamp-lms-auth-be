using lms_auth_be.Data;
using lms_auth_be.DBContext;
using lms_auth_be.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.Repositories;

public class UsersRepo(DatabaseContext dbContext) : GenericRepo<User>(dbContext), IUsersRepo
{
    public async Task<User?> GetByEmail(string email)
    {
        return await this.table.FirstOrDefaultAsync(u => u.Email == email);
    }
}


