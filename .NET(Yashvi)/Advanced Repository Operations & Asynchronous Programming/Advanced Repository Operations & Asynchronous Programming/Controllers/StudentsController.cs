using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _repository;

    public StudentsController(IStudentRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents([FromQuery] StudentQueryParameters parameters)
    {
        var students = await _repository.GetAllAsync(parameters);
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudent(int id)
    {
        var student = await _repository.GetByIdAsync(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(Student student)
    {
        await _repository.AddAsync(student);
        return Ok(student);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStudent(Student student)
    {
        await _repository.UpdateAsync(student);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
