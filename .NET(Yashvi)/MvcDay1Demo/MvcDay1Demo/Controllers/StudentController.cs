using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcCrudDemo.Models;

namespace MvcCrudDemo.Controllers
{
    public class StudentController : Controller
    {
 
        static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Yashvi Patel", Age = 21, Email = "yashvi@gmail.com" },
            new Student { Id = 2, Name = "jahi Dhaduk", Age = 17, Email = "jahi@gmail.com" }
        };

        public ActionResult Index()
        {
            return View(students);
        }

        public ActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = students.Max(x => x.Id) + 1; // Auto ID
                students.Add(s);
                return RedirectToAction("Index");
            }
            return View(s);
        }

        public ActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            var existing = students.FirstOrDefault(x => x.Id == s.Id);
            if (existing != null)
            {
                existing.Name = s.Name;
                existing.Age = s.Age;
                existing.Email = s.Email;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            students.Remove(student);
            return RedirectToAction("Index");
        }
    }
}
