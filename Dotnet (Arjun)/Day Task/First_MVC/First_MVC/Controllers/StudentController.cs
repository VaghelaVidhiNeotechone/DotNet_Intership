using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    public class StudentController : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, int age)
        {
            ViewBag.Message = $"student '{name}' (age {age}) Add Successfully!";
            return View();
        }

    }
}
