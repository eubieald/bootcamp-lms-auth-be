using lms_auth_be.Data;
using lms_auth_be.DBContext;
using lms_auth_be.Interfaces;

namespace lms_auth_be.Repositories;

public class CourseRepo(DatabaseContext dbContext) : GenericRepo<Course>(dbContext), ICourseRepo
{
}
