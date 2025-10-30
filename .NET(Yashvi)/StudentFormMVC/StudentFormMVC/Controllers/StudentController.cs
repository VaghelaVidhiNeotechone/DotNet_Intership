using Microsoft.AspNetCore.Mvc;
using StudentFormMVC.Models;

namespace StudentFormMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("List"); 
            }
            return View(student);
        }

        public IActionResult List()
        {
            var students = _context.Students.ToList(); 
            return View(students);
        }
    }
}
