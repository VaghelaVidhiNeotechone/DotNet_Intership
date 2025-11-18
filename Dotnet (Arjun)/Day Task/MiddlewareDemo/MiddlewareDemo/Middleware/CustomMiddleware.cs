namespace MiddlewareDemo.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Request Before
            Console.WriteLine("➡ Custom Middleware: Request Processing Start");

            await _next(context); // next middleware

            // Response After
            Console.WriteLine("⬅ Custom Middleware: Response Processing End");
        }
    }
}
