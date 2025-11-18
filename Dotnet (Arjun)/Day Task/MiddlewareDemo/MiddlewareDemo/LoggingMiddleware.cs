using System.Diagnostics;

namespace MiddlewareDemo
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Request log
            var stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"➡ Request: {context.Request.Method} {context.Request.Path}");

            // Next Middleware / Controller call
            await _next(context);

            // Response log
            stopwatch.Stop();
            Console.WriteLine($"⬅ Response: {context.Response.StatusCode} | Time Taken: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
