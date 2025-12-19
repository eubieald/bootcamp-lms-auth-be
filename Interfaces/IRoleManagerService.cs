using lms_auth_be.Enums;

namespace lms_auth_be.Interfaces
{
    public interface IRoleManagerService
    {
        IAdminRepo AdminRepo { get; set; }
        IStudentRepo StudentRepo { get; set; }
        ITeacherRepo TeacherRepo { get; set; }

        Task<List<UserRoleEnums>> GetRolesAsync(int id);
    }
}