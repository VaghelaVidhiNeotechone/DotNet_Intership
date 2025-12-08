using System.Linq;
using System.Security.Claims;
using CRUD_with_WebAPI.Data;
using CRUD_with_WebAPI.DTOs;
using CRUD_with_WebAPI.Helpers;
using CRUD_with_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_with_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;

        public StudentsController(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _context = context;
        }


        // GET api/debug/students
        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var (isValid, _, error) = JwtHelper.ValidateToken(authHeader, _config);
            if (!isValid) return Unauthorized(new { valid = false, error });

            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }

        // GET api/debug/students/{id}
        [HttpGet("students/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var (isValid, _, error) = JwtHelper.ValidateToken(authHeader, _config);
            if (!isValid) return Unauthorized(new { valid = false, error });

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        // POST api/debug/students
        [HttpPost("students")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequestDTO request)
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var (isValid, _, error) = JwtHelper.ValidateToken(authHeader, _config);
            if (!isValid) return Unauthorized(new { valid = false, error });

            var student = new Student
            {
                Name = request.Name,
                Age = request.Age,
                City = request.City
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        //PUT api/debug/students/{id}
        [HttpPut("students/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student updateRequest)
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var (isValid, _, error) = JwtHelper.ValidateToken(authHeader, _config);
            if (!isValid) return Unauthorized(new { valid = false, error });

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            student.Name = updateRequest.Name;
            student.Age = updateRequest.Age;
            student.City = updateRequest.City;

            await _context.SaveChangesAsync();
            return Ok(student);
        }

        // DELETE api/debug/students/{id}
        [HttpDelete("students/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var (isValid, _, error) = JwtHelper.ValidateToken(authHeader, _config);
            if (!isValid) return Unauthorized(new { valid = false, error });

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Deleted Successfully" });
        }

    }
}