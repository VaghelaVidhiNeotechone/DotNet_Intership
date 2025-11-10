using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBFirstApproach_CRUD.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace DBFirstApproach_CRUD.Controllers
{
    public class UserRegistrationsController : Controller
    {
        private readonly RegistrationCrudDbContext _context;

        public UserRegistrationsController(RegistrationCrudDbContext context)
        {
            _context = context;
        }

        // GET: UserRegistrations
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserRegistrations.ToListAsync());
        }

        // GET: UserRegistrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRegistration = await _context.UserRegistrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userRegistration == null)
            {
                return NotFound();
            }

            return View(userRegistration);
        }

        // GET: UserRegistrations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserRegistrations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Email,Password,Gender,Skills,Country,Address")] UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                // Hash the password into a short numeric value
                if (!string.IsNullOrEmpty(userRegistration.Password))
                {
                    userRegistration.Password = GenerateShortNumericHash(userRegistration.Password);
                }

                _context.Add(userRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userRegistration);
        }

        // GET: UserRegistrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRegistration = await _context.UserRegistrations.FindAsync(id);
            if (userRegistration == null)
            {
                return NotFound();
            }
            return View(userRegistration);
        }

        // POST: UserRegistrations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection form, UserRegistration user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            // Capture all checked checkboxes
            var selectedSkills = form["Skills"];
            user.Skills = string.Join(",", selectedSkills);

            if (ModelState.IsValid)
            {
                try
                {
                    // Get existing record
                    var existingUser = _context.UserRegistrations.AsNoTracking().FirstOrDefault(u => u.Id == id);
                    if (existingUser == null)
                    {
                        return NotFound();
                    }

                    //  Preserve old password if not changed
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        user.Password = GenerateShortNumericHash(user.Password);
                    }
                    else
                    {
                        user.Password = existingUser.Password;
                    }

                    _context.Update(user);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.UserRegistrations.Any(e => e.Id == user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        // GET: UserRegistrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRegistration = await _context.UserRegistrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userRegistration == null)
            {
                return NotFound();
            }

            return View(userRegistration);
        }

        // POST: UserRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userRegistration = await _context.UserRegistrations.FindAsync(id);
            if (userRegistration != null)
            {
                _context.UserRegistrations.Remove(userRegistration);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRegistrationExists(int id)
        {
            return _context.UserRegistrations.Any(e => e.Id == id);
        }

        // Helper: Generate short numeric hash (10 digits)
        private string GenerateShortNumericHash(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                long numericHash = BitConverter.ToInt64(hashBytes, 0);
                numericHash = Math.Abs(numericHash);
                return (numericHash % 10000000000).ToString("D10"); // Always 10 digits
            }
        }
    }
}
