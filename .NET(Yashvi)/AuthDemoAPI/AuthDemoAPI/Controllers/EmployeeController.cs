using AuthDemoAPI.Data;
using AuthDemoAPI.DTOs;
using AuthDemoAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/employee")]
public class EmployeeController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _context.Employees.ToListAsync();
        return Ok(employees);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            Name = dto.Name,
            Department = dto.Department,
            Salary = dto.Salary
        };

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return Ok(employee);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDto dto)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
            return NotFound("Employee not found");

        employee.Name = dto.Name;
        employee.Department = dto.Department;
        employee.Salary = dto.Salary;

        await _context.SaveChangesAsync();

        return Ok(employee);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
            return NotFound("Employee not found");

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();

        return Ok("Employee deleted successfully");
    }
}
 