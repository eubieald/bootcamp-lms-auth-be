using lms_auth_be.Data;

namespace lms_auth_be.DTOs;
public static class UsersDtosHelper
{
    public static UsersDtos ToDto(this User users)
    {
        return new UsersDtos(users.UserName, users.FirstName, users.LastName);
    }
}
