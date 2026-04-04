using Core.Logging;
using DataAccess.EFCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceScopeFactory _scopeFactory;
    public ExceptionMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
    {
        _next = next; _scopeFactory = scopeFactory;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<EducationDbContext>();
            var log = new AppLog
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Source = ex.Source ?? "ExceptionMiddleware",
                CreatedDate = DateTime.UtcNow,
                Level = "Error",
                Endpoint = context?.Request?.Path.Value ?? "Unknown",
                HttpMethod = context?.Request?.Method ?? "Unknown",
                UserId = context?.User?.Identity?.IsAuthenticated == true
                         ? context.User.FindFirst("sub")?.Value
                         : null
            };


            db.AppLogs.Add(log);

            await db.SaveChangesAsync();

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var response = JsonSerializer.Serialize(new { StatusCode = 500, Message = "Internal Server Error" });

            await context.Response.WriteAsync(response);
        }
    }
}


