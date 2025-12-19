using lms_auth_be.Data;
using lms_auth_be.DBContext;
using lms_auth_be.Interfaces;

namespace lms_auth_be.Repositories;

public class StudentRepo(DatabaseContext dbContext) : GenericRepo<Student>(dbContext), IStudentRepo
{
}
