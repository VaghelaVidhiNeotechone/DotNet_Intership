namespace MiddlewareWebAPI.Middlewares
{
    public class CustomTemplateMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomTemplateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Before request
            Console.WriteLine("➡ Custom Middleware: Before Request");

            await _next(context);

            // After response
            Console.WriteLine("⬅ Custom Middleware: After Response");
        }
    }

    public static class CustomTemplateMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomTemplate(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomTemplateMiddleware>();
        }
    }
}
