using lms_auth_be.Data;
using lms_auth_be.DTOs;

namespace lms_auth_be.Mapper;

public static class UserDtoMapper
{
    public static UsersDto ToDto(this User users, IEnumerable<string>? roles = null)
    {
        return new UsersDto(users.Email, users.FirstName, users.LastName, roles);
    }
}
