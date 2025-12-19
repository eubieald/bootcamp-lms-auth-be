using lms_auth_be.Data;
using lms_auth_be.Enums;
using lms_auth_be.Interfaces;

namespace lms_auth_be.Services;

public class RoleManagerService(IAdminRepo adminRepo, ITeacherRepo teacherRepo, IStudentRepo studentRepo) : IRoleManagerService
{
    public IAdminRepo AdminRepo { get; set; } = adminRepo;

    public ITeacherRepo TeacherRepo { get; set; } = teacherRepo;

    public IStudentRepo StudentRepo { get; set; } = studentRepo;

    public async Task<List<UserRoleEnums>> GetRolesAsync(int id)
    {
        List<UserRoleEnums> roles = [];
        if (await this.AdminRepo.GetByIdAsync(id) != null)
            roles.Add(UserRoleEnums.Admin);

        if (await this.TeacherRepo.GetByIdAsync(id) != null)
            roles.Add(UserRoleEnums.Teacher);

        if (await this.StudentRepo.GetByIdAsync(id) != null)
            roles.Add(UserRoleEnums.Student);

        return roles;
    }
}
