using System.Diagnostics;

namespace MiddlewareWebAPI.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();

            _logger.LogInformation("➡ Request: {method} {url}",
                context.Request.Method, context.Request.Path);

            await _next(context);

            sw.Stop();

            _logger.LogInformation("⬅ Response: {status} | Time: {time} ms",
                context.Response.StatusCode, sw.ElapsedMilliseconds);
        }
    }

    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggingMiddleware>();
        }
    }
}
