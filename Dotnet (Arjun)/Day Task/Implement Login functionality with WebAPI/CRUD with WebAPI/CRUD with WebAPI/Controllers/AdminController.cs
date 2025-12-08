using CRUD_with_WebAPI.Data;
using CRUD_with_WebAPI.Helpers;
using CRUD_with_WebAPI.Models;
using CRUD_with_WebAPI.Data;    
using CRUD_with_WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CRUD_with_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;

        public AdminController(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("assign-role")]
        public IActionResult AssignRole([FromBody] AssignRoleRequest request)
        {
            // JWT Validate
            var authHeader = Request.Headers["Authorization"].ToString();
            var (isValid, principal, error) = JwtHelper.ValidateToken(authHeader, _config);
            if (!isValid) return Unauthorized(new { valid = false, error });

            // Check Admin Role from Token
            var role = principal?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (role != "Admin")
                //return Forbid("Only Admin can assign roles");
                return StatusCode(403, new { message = "Only Admin can assign roles" });

            var user = _context.Users.FirstOrDefault(x => x.Username == request.Username);
            if (user == null)
                return NotFound(new { message = "User not found" });

            user.Role = request.Role;
            _context.SaveChanges();

            return Ok(new { message = $"Role '{request.Role}' assigned to {request.Username}" });
        }

    }

    public class AssignRoleRequest
    {
        public string Username { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
