using CRUD_with_WebAPI.Data;
using CRUD_with_WebAPI.DTOs;
using CRUD_with_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRUD_with_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }


        [AllowAnonymous]
        [HttpPost("register")]
        [SwaggerRequestExample(typeof(RegisterRequestDTO), typeof(RegisterExample))] // optional
        public IActionResult Register([FromBody] RegisterRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_context.Users.Any(x => x.Username == request.Username))
                return BadRequest("Username already exists");

            if (request.Password != request.ConfirmPassword)
                return BadRequest("Password and Confirm Password do not match");

            var user = new User
            {
                FullName = request.FullName,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password, 
                ConfirmPassword = request.ConfirmPassword,
                Age = request.Age,
                BirthDate = request.BirthDate,
                MobileNumber = request.MobileNumber,
                City = request.City,
                State = request.State,
                Country = request.Country,
                Gender = request.Gender,
                MarriedStatus = request.MarriedStatus,
                ImageUrl = request.ImageUrl,
                Role = "User" // ◀️ server-side set — saved into DB
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully (Role = User)");
        }


        // LOGIN API
        [AllowAnonymous]
        [HttpPost("login")]
        [SwaggerRequestExample(typeof(LoginRequestDTO), typeof(LoginExample))]
        public IActionResult Login([FromBody] LoginRequestDTO request)
        {
            var dbUser = _context.Users.FirstOrDefault(x => x.Username == request.Username && x.Password == request.Password);
            if (dbUser == null)
                return Unauthorized("Invalid Username or Password");

            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, dbUser.Username),
                    new Claim(ClaimTypes.Role, dbUser.Role),
                    new Claim("role", dbUser.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }
}
