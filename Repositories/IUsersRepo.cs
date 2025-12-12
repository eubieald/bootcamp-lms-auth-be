using lms_auth_be.Data;

namespace lms_auth_be.Repositories
{
    public interface IUsersRepo
    {
        System.Threading.Tasks.Task DeleteUsers(User user);
        Task<List<User>> GetAll();
        Task<User?> GetByUserName(string username);
        System.Threading.Tasks.Task InsertUsersAsync(User user);
        System.Threading.Tasks.Task SaveUsers(User user);
    }
}