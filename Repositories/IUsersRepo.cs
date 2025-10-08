using lms_auth_be.Data;

namespace lms_auth_be.Repositories
{
    public interface IUsersRepo
    {
        Task DeleteUsers(Users user);
        Task<List<Users>> GetAll();
        Task<Users?> GetByUserName(string username);
        Task InsertUsersAsync(Users user);
        Task SaveUsers(Users user);
    }
}