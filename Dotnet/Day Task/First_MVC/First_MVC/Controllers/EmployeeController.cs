using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult Index()
        {
            ViewData["Message"] = "Hello from ViewData!";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Greeting = "Welcome using ViewBag!";
            return View();
        }

        public ActionResult First()
        {
            TempData["Note"] = "This message comes from TempData.";
            return RedirectToAction("Second");
        }

        public ActionResult Second()
        {
            return View();
        }

        public IActionResult Details()
        {
            Employee emp = new Employee()
            {
                Id = 1,
                Name = "Rahul Patel",
                Age = 20
            };

            return View(emp);
        }
    }
}
