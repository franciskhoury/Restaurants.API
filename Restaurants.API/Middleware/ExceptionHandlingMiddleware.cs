
using Restaurants.Domain.Exceptions;

namespace Restaurants.API.Middleware;

public class ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException nf)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(nf.Message);
            logger.LogWarning(nf.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Error occured on the server.");
        }
    }
}
