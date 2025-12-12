using Microsoft.EntityFrameworkCore;
using lms_auth_be.Data;

namespace lms_auth_be.DBContext;

public class UsersDBContext : DbContext
{
    public UsersDBContext(DbContextOptions<UsersDBContext> options) : base(options)
    {
    }

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

        // Course to User
        modelBuilder.Entity<Course>()
            .HasOne(x => x.Owner)
            .WithMany(x => x.OwnedCourses)
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        // EnrolledCourse to Course
        modelBuilder.Entity<EnrolledCourse>()
            .HasOne(x => x.Course)
            .WithMany(x => x.Enrolled)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // EnrolledCourse to Student
        modelBuilder.Entity<EnrolledCourse>()
            .HasOne(x => x.Student)
            .WithMany(x => x.EnrolledCourses)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Task to Course
        modelBuilder.Entity<Data.Task>()
            .HasOne(x => x.Course)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Submission to Task
        modelBuilder.Entity<Submission>()
            .HasOne(x => x.Task)
            .WithMany(x => x.Submissions)
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        // Submission to EnrolledCourse
        modelBuilder.Entity<Submission>()
            .HasOne(x => x.EnrolledCourse)
            .WithMany(x => x.Submissions)
            .HasForeignKey(x => x.EnrolledCourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Admin to User
        modelBuilder.Entity<Admin>()
            .HasOne(x => x.User)
            .WithOne(x => x.Admin)
            .HasForeignKey<Admin>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);

        // Teacher to User
        modelBuilder.Entity<Teacher>()
            .HasOne(x => x.User)
            .WithOne(x => x.Teacher)
            .HasForeignKey<Teacher>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);

        // Student to User
        modelBuilder.Entity<Student>()
            .HasOne(x => x.User)
            .WithOne(x => x.Student)
            .HasForeignKey<Student>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
