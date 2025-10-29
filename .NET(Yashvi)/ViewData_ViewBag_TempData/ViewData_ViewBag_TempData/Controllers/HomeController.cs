using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewData_ViewBag_TempData.Models;

namespace ViewData_ViewBag_TempData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData vd= new ViewData();
            ViewData["viewdata"] = vd;

            ViewBag vb = new ViewBag();
            ViewBag.viewbag= vb;

            Employee emp = new Employee()
            {
                EmpId = 1,
                EmpName = "yashvi",
                Designation = "Manager",
                Salary = 30000
            };
            TempData["myEmployee"] = emp;

            return View();
        }

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
