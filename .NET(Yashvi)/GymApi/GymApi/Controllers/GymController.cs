using Microsoft.AspNetCore.Mvc;
using GymApi.Data;
using GymApi.Models;
using GymApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GymController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/gym
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymUser>>> GetAll()
        {
            return await _context.GymUsers.ToListAsync();
        }

        // GET: api/gym/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GymUser>> GetById(int id)
        {
            var user = await _context.GymUsers.FindAsync(id);

            if (user == null)
                return NotFound();

            return user;
        }

        // POST: api/gym
        [HttpPost]
        public async Task<ActionResult<GymUser>> Create(CreateGymUserDto dto)
        {
            var user = new GymUser
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Mobile = dto.Mobile,
                Age = dto.Age
            };

            _context.GymUsers.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT: api/gym/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateGymUserDto dto)
        {
            var user = await _context.GymUsers.FindAsync(id);

            if (user == null)
                return NotFound();

            user.FullName = dto.FullName;
            user.Mobile = dto.Mobile;
            user.Email = dto.Email;
            user.Age = dto.Age;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/gym/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.GymUsers.FindAsync(id);

            if (user == null)
                return NotFound();

            _context.GymUsers.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
