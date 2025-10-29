using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace AspNetCoreRoutingAndFiltersDemo.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string? controller = context.RouteData.Values["controller"]?.ToString();
            string? action = context.RouteData.Values["action"]?.ToString();
            Debug.WriteLine($"[START] {controller}/{action} at {DateTime.Now}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string? controller = context.RouteData.Values["controller"]?.ToString();
            string? action = context.RouteData.Values["action"]?.ToString();
            Debug.WriteLine($"[END] {controller}/{action} at {DateTime.Now}");
        }
    }
}
