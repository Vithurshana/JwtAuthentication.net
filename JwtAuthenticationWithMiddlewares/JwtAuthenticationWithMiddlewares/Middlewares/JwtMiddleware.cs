using JwtAuthenticationWithMiddlewares.DTOs.Responses;
using JwtAuthenticationWithMiddlewares.Helpers.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace JwtAuthenticationWithMiddlewares.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string? token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")[1];

            if (token == null)
            {
                if (IsEnabledUnauthorizedRoute(httpContext))
                {
                    return _next(httpContext);
                }

                BaseResponse response = new BaseResponse
                {
                    status_code = StatusCodes.Status401Unauthorized,
                    data = new { message = "Unauthorized" },
                };

                httpContext.Response.StatusCode = response.status_code;
                httpContext.Response.ContentType = "application/json";
                return httpContext.Response.WriteAsJsonAsync(response);

            }

            else
            {
                if (JwtUtils.ValidateJwtToken(token))
                {
                    return _next(httpContext);
                }

                BaseResponse response = new BaseResponse
                {
                    status_code = StatusCodes.Status401Unauthorized,
                    data = new { message = "Unauthorized" },
                };

                httpContext.Response.StatusCode = response.status_code;
                httpContext.Response.ContentType = "application/json";
                return httpContext.Response.WriteAsJsonAsync(response);

            }

            
        }

        private bool IsEnabledUnauthorizedRoute(HttpContext httpContext)
        {
            List<string> enabledRoutes = new List<string>
            {
                "/api/user/createuser",
                "/api/authenticate/authenticate",
            };

            bool isEnableUnauthorizedRoute = false;

            if (httpContext.Request.Path.Value is not null)
            {
                isEnableUnauthorizedRoute = enabledRoutes.Contains(httpContext.Request.Path.Value.ToLower());
            }


            return isEnableUnauthorizedRoute;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtMiddleware>();
        }
    }
}
