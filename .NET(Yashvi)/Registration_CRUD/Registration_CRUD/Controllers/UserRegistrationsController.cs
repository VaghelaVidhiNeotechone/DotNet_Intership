using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registration_CRUD.Data;
using RegistrationFormMVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationFormMVC.Controllers
{
    public class UserRegistrationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserRegistrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🟢 INDEX - List all users
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _context.UserRegistrations.ToListAsync();
            return View(users);
        }

        // 🟢 DETAILS - Show user details
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _context.UserRegistrations
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        // 🟢 CREATE - Show form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 🟢 CREATE - Save data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserRegistration model, string[] Skills)
        {
            if (ModelState.IsValid)
            {
                model.Skills = string.Join(",", Skills);
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // 🟢 EDIT - Show edit form
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _context.UserRegistrations.FindAsync(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // 🟢 EDIT - Save updated data
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(int id, UserRegistration model, string[] Skills)
        {
            if (id != model.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    model.Skills = string.Join(",", Skills);
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.UserRegistrations.Any(e => e.Id == model.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View("Edit", model);
        }

        // 🟢 DELETE - Confirm page
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _context.UserRegistrations
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        // 🟢 DELETE - Remove user
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.UserRegistrations.FindAsync(id);

            if (user == null)
                return NotFound();

            _context.UserRegistrations.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
