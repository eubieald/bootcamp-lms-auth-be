using lms_auth_be.Data;
using lms_auth_be.Enums;

namespace lms_auth_be.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user, UserRoleEnums role = UserRoleEnums.Admin);
    }
}