using CompanyModule.Interface.Services;
using CompanyModule.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CompanyModule.Controllers.Version1
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserFileController : ControllerBase
    {
        private readonly IUserFileService _userFileService;

        public UserFileController(IUserFileService userFileService)
        {
            _userFileService = userFileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userFileService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _userFileService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var result = await _userFileService.GetByUserIdAsync(userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserFile userFile)
        {
            var result = await _userFileService.CreateAsync(userFile);
            return CreatedAtAction(nameof(GetById), new { id = result.userfileid }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserFile userFile)
        {
            userFile.userfileid = id;
            var result = await _userFileService.UpdateAsync(userFile);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userFileService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}