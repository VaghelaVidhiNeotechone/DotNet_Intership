using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace First_MVC.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        private Stopwatch stopwatch;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch = Stopwatch.StartNew();
            Debug.WriteLine($"[START] {context.ActionDescriptor.DisplayName} at {DateTime.Now}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            Debug.WriteLine($"[END] {context.ActionDescriptor.DisplayName} took {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
