using Core.Logging;
using DataAccess.EFCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Utilities.ExceptionMiddlewares
{
    public class SuccessLoggingFilter : IAsyncActionFilter
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public SuccessLoggingFilter(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var executedContext = await next();

            if (executedContext.Exception == null)
            {
                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<EducationDbContext>();

                var userId = context.HttpContext.User?.Identity?.IsAuthenticated == true
                    ? context.HttpContext.User.FindFirst("sub")?.Value
                    : null;

                var sourceName = context.ActionDescriptor?.DisplayName ?? "SuccessPipeline";

                var log = new AppLog
                {
                    Message = "Request successfully completed",
                    Level = "Success",
                    CreatedDate = DateTime.UtcNow,
                    Endpoint = context.HttpContext.Request.Path,
                    HttpMethod = context.HttpContext.Request.Method,
                    UserId = userId,
                    Source = sourceName,
                    StackTrace = "Succeeded" 
                };

                db.AppLogs.Add(log);
                await db.SaveChangesAsync();
            }
        }
    }


}
