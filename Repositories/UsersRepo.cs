using lms_auth_be.Data;
using lms_auth_be.DBContext;
using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.Repositories
{
    public class UsersRepo : IUsersRepo
    {
        private UsersDBContext _dbContext;

        public UsersRepo(UsersDBContext context)
        {
            this._dbContext = context;
        }
        public async Task<List<Users>> GetAll() => await this._dbContext.Users.ToListAsync();

        public async Task<Users?> GetByUserName(string username)
        {
            return await this._dbContext.Users.FindAsync(username);
        }

        public async Task InsertUsersAsync(Users user)
        {
            await this._dbContext.Users.AddAsync(user);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task SaveUsers(Users user)
        {
            await this._dbContext.SaveChangesAsync();
        }

        public async Task DeleteUsers(Users user)
        {
            this._dbContext.Users.Remove(user);
            await this._dbContext.SaveChangesAsync();
        }
    }
}


