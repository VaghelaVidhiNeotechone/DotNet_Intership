using AuthDemoAPI.Data;
using AuthDemoAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthDemoAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize] // 🔓 Allow authenticated users, NOT role restricted here
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto dto)
        {
            // 🔐 MANUAL ROLE CHECK
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(403, new
                {
                    message = "Only Admin can assign roles"
                });
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == dto.Username);

            if (user == null)
                return NotFound(new { message = "User not found" });

            user.Role = dto.Role;
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = $"Role '{dto.Role}' assigned to user '{dto.Username}'"
            });
        }
    }
}
