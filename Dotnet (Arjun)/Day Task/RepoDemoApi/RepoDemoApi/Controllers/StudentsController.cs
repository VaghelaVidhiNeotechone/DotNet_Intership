using Microsoft.AspNetCore.Mvc;
using RepoDemoApi.Models;
using RepoDemoApi.Repositories;

namespace RepoDemoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository<Student> _studentRepo;

        public StudentsController(IRepository<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepo.GetAllAsync();
            return Ok(students);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _studentRepo.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }
    }
}
