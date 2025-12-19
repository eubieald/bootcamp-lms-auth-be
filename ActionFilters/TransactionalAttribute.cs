using lms_auth_be.DBContext;
using Microsoft.AspNetCore.Mvc.Filters;

namespace lms_auth_be.ActionFilters;

[AttributeUsage(AttributeTargets.Method)]
public class TransactionalAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var dbContext = context.HttpContext.RequestServices
            .GetRequiredService<DatabaseContext>();

        await using var transaction = await dbContext.Database.BeginTransactionAsync();

        var executedContext = await next();

        if (executedContext.Exception != null && !executedContext.ExceptionHandled)
        {
            await transaction.RollbackAsync();
            return;
        }

        await transaction.CommitAsync();
    }
}
