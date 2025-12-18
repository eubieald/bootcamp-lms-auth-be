using lms_auth_be.Data;
using lms_auth_be.DBContext;
using lms_auth_be.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lms_auth_be.Repositories;

public class CourseRepo(DatabaseContext dbContext, DbSet<Course> table) : GenericRepo<Course>(dbContext, table), ICourseRepo
{
}
