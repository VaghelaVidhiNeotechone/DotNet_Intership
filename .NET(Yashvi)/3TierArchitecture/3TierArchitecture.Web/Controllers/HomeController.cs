using Microsoft.AspNetCore.Mvc;
using _3TierArchitecture.Web.Models;
using System.Diagnostics;

namespace _3TierArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Products");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
