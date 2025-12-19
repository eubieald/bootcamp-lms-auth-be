using lms_auth_be.Interfaces;
using lms_auth_be.Repositories;

namespace lms_auth_be;

public static class ProgramExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepo, UsersRepo>();
        services.AddScoped<ICourseRepo, CourseRepo>();

        return services;
    }
}
