using lms_auth_be.DBContext;
using lms_auth_be.Interfaces;
using lms_auth_be.Repositories;

namespace lms_auth_be;

public static class ProgramExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var context = provider.GetRequiredService<DatabaseContext>();

        services.AddScoped<IUsersRepo>(provider => new UsersRepo(context, context.Users));
        services.AddScoped<ICourseRepo>(provider => new CourseRepo(context, context.Courses));

        return services;
    }
}
