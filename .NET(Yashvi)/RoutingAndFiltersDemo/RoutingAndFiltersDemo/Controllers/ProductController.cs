using AspNetCoreRoutingAndFiltersDemo.Filters;
using Microsoft.AspNetCore.Mvc;
//using RoutingAndFiltersDemo.Filters;

namespace RoutingAndFiltersDemo.Controllers
{
    [ServiceFilter(typeof(LogActionFilter))] // 👈 Add this line
    public class ProductController : Controller
    {
        public IActionResult Details(int id)
        {
            ViewBag.Message = $"Product details for ID = {id}";
            return View();
        }

        [Route("product/category/{name}")]
        public IActionResult Category(string name)
        {
            ViewBag.Message = $"Category: {name}";
            return View("Details");
        }
    }
}
