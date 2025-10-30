using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    public class UserController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "User Register successfully!";
                return View();
            }

            return View(user);
        }

        public ActionResult Success()
        {
            return View();
        }

    }
}
