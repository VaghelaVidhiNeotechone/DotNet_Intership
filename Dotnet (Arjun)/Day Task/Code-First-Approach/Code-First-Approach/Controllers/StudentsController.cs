using Code_First_Approach.Data;
using Code_First_Approach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Code_First_Approach.Controllers
{
    public class StudentsController : Controller
    {
        //private readonly SchoolContext _context;

        //public StudentsController(SchoolContext context)
        //{
        //    _context = context;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    var students = await _context.Students
        //        .Include(s => s.StudentCourses)
        //        .ThenInclude(sc => sc.Course)
        //        .ToListAsync();
        //    return View(students);
        //}

        //public IActionResult Create() => View();

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(student);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(student);
        //}



        private readonly SchoolContext _context;
        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .ToListAsync();
            return View(students);
        }

        public IActionResult Create()
        {
            ViewBag.Courses = new MultiSelectList(_context.Courses, "CourseId", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student, int[] selectedCourses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();

                foreach (var courseId in selectedCourses)
                {
                    _context.StudentCourses.Add(new StudentCourse
                    {
                        StudentId = student.StudentId,
                        CourseId = courseId
                    });
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Courses = new MultiSelectList(_context.Courses, "CourseId", "Title");
            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students
                .Include(s => s.StudentCourses)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            if (student == null) return NotFound();

            ViewBag.Courses = new MultiSelectList(_context.Courses, "CourseId", "Title",
                student.StudentCourses.Select(sc => sc.CourseId));
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student, int[] selectedCourses)
        {
            if (ModelState.IsValid)
            {
                _context.Update(student);
                await _context.SaveChangesAsync();

                var existing = _context.StudentCourses.Where(sc => sc.StudentId == student.StudentId);
                _context.StudentCourses.RemoveRange(existing);

                foreach (var courseId in selectedCourses)
                {
                    _context.StudentCourses.Add(new StudentCourse
                    {
                        StudentId = student.StudentId,
                        CourseId = courseId
                    });
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Courses = new MultiSelectList(_context.Courses, "CourseId", "Title", selectedCourses);
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
