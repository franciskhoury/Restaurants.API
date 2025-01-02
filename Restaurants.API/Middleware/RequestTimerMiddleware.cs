using System.Diagnostics;

namespace Restaurants.API.Middleware;

public class RequestTimerMiddleware(ILogger<RequestTimerMiddleware> logger, IConfiguration configuration) : IMiddleware
{
    private int _threshold;
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (int.TryParse(configuration.GetSection("GeneralSettings")["RequestTimerLoggingThresholdMS"], out _threshold))
        {
            var stopWatch = Stopwatch.StartNew();
            await next.Invoke(context);
            stopWatch.Stop();
            if (stopWatch.ElapsedMilliseconds >= _threshold)
            {
                logger.LogInformation("Request [{Verb}] at {Path} took {Time} ms.",
                    context.Request.Method,
                    context.Request.Path,
                    stopWatch.ElapsedMilliseconds);
            }
        }
        else
        {
            logger.LogInformation("Request Timer Logging not configured.");
            await next.Invoke(context);
        }



    }
}
