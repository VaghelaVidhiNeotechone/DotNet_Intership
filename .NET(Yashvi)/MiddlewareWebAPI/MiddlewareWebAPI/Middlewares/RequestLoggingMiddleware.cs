using System.Diagnostics;

namespace WebApiDemo.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            Console.WriteLine($"[Middleware] Incoming Request: {context.Request.Method} {context.Request.Path}");

            // ⭐ Add the header BEFORE the response starts
            context.Response.OnStarting(() =>
            {
                context.Response.Headers["X-Processing-Time-ms"] = stopwatch.ElapsedMilliseconds.ToString();
                return Task.CompletedTask;
            });

            await _next(context);

            stopwatch.Stop();

            Console.WriteLine($"[Middleware] Completed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
