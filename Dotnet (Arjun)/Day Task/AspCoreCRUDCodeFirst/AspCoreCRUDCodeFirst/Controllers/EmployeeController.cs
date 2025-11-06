using AspCoreCRUDCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCoreCRUDCodeFirst.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDBContext _Db;

        public EmployeeController(EmployeeDBContext context)
        {
            this._Db = context;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _Db.Employees.ToListAsync();
            return View(employees);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee obj)
        {
            if(ModelState.IsValid)
            {
                _Db.Add(obj);
                await _Db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Employee Added Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _Db.Employees.FindAsync(id);
            if (employee == null) 
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee obj)
        {
            if (id != obj.Emp_Id) 
            {
                return NotFound();
            }
            if (ModelState.IsValid) 
            {
                _Db.Update(obj);
                await _Db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Employee Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _Db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _Db.Employees.FindAsync(id);
            if(employee != null)
            {
                _Db.Employees.Remove(employee);
                await _Db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Employee Deleted Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Employee Not Found";
            }
            return RedirectToAction("Index");
        }
    }
}
