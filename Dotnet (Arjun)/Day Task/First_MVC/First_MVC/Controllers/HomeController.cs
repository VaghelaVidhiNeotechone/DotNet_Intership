using System.Diagnostics;
using First_MVC.Filters;
using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [LogActionFilter]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Custom Action Filter Example!";
            return View();
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
