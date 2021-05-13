using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApplication
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["userId"]))
            {
                await context.Response.WriteAsync("UserId not Provided cannot load data");
            }
            else
            {
                await _next(context);
            }
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseValidation(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ValidationMiddleware>();
        }
    }
}