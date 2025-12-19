using lms_auth_be.Data;
using lms_auth_be.DBContext;
using lms_auth_be.Interfaces;

namespace lms_auth_be.Repositories;

public class TeacherRepo(DatabaseContext dbContext) : GenericRepo<Teacher>(dbContext), ITeacherRepo
{
}
