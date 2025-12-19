using lms_auth_be.Data;

namespace lms_auth_be.Interfaces;

public interface IUsersRepo : IGenericRepo<User>
{
    Task<User?> GetByEmail(string username);
}