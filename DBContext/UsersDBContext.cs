using Microsoft.EntityFrameworkCore;
using lms_auth_be.Data;
using lms_auth_be.DBContext.Configurations;

namespace lms_auth_be.DBContext;

public class UsersDBContext(DbContextOptions<UsersDBContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<EnrolledCourse> EnrolledCourses { get; set; }
    public DbSet<Data.Task> Tasks { get; set; }
    public DbSet<Submission> Submissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.AddUserSchemaConfig();
        modelBuilder.AddCourseSchemaConfig();
        modelBuilder.AddEnrolledCourseSchemaConfig();
        modelBuilder.AddTaskSchemaConfig();
        modelBuilder.AddSubmissionSchemaConfig();
        modelBuilder.AddAdminSchemaConfig();
        modelBuilder.AddTeacherSchemaConfig();
        modelBuilder.AddStudentSchemaConfig();
    }
}
