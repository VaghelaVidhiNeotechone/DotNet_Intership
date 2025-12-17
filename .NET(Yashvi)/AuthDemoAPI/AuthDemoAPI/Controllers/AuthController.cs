using AuthDemoAPI.Data;
using AuthDemoAPI.DTOs;
using AuthDemoAPI.Helpers;
using AuthDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthDemoAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtHelper _jwtHelper;

        public AuthController(ApplicationDbContext context, JwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }

        // ---------------- REGISTER ----------------
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = dto.Username.Trim().ToLower();

            if (await _context.Users.AnyAsync(u => u.Username.ToLower() == username))
                return BadRequest("Username already exists");

            var user = new User
            {
                FullName = dto.FullName,
                Username = username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Age = dto.Age,
                BirthDate = dto.BirthDate,
                MobileNumber = dto.MobileNumber,
                City = dto.City,
                State = dto.State,
                Country = dto.Country,
                Gender = dto.Gender,
                MarriedStatus = dto.MarriedStatus,
                ImageUrl = dto.ImageUrl,
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

        // ---------------- LOGIN ----------------
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = dto.Username.Trim().ToLower();

            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Username.ToLower() == username);

            if (user == null)
                return Unauthorized("Invalid username or password");

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!isPasswordValid)
                return Unauthorized("Invalid username or password");

            var token = _jwtHelper.GenerateToken(user.Username, user.Role);

            return Ok(new
            {
                token,
                user = new
                {
                    user.Id,
                    user.Username,
                    user.Email,
                    user.Role
                }
            });
        }
    }
}
