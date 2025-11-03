using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AJAXCrudDemo.Models;

namespace AJAXCrudDemo.Controllers
{
    public class EmployeesController : Controller
    {
        private AJAXCrudDemoDBEntities db = new AJAXCrudDemoDBEntities();

        // GET: Employees

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetEmployees()
        {
            var employees = db.Employees.ToList();
            return PartialView("_EmployeeList", employees);
        }

        [HttpPost]
        public JsonResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult Update(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var existing = db.Employees.Find(emp.EmployeeID);
                if (existing != null)
                {
                    existing.EmpName = emp.EmpName;
                    existing.Email = emp.Email;
                    existing.Age = emp.Age;
                    existing.Department = emp.Department;
                    existing.JoinDate = emp.JoinDate;
                    db.SaveChanges();
                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var emp = db.Employees.Find(id);
            if (emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
