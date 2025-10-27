using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    public class EmployeeController : Controller
    {
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
