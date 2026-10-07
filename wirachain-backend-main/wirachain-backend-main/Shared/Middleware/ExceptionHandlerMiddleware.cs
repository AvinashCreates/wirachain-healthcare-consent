using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Formatters;
using wirachain_backend.Shared.Extensions.Exceptions;

namespace wirachain_backend.Shared.Middleware;

public class ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
{
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Ocurrió un error inesperado.");
            httpContext.Response.ContentType = MediaTypeNames.Application.Json;
            switch (e)
            {
                case KeyNotFoundException _:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                case UnauthorizedAccessException _:
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    break;
                case ArgumentException _:
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(
                new
                {
                    statusCode = httpContext.Response.StatusCode,
                    message = e.Message
                });
            await httpContext.Response.WriteAsync(result);
        }
    }
}