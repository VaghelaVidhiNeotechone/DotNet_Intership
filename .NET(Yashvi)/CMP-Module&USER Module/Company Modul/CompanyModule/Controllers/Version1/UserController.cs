using CompanyModule.Interface.Services.User;
using CompanyModule.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace CompanyModule.Controllers.Version1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllAsync();
            return !result.Success ? BadRequest(result) : Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _userService.GetByIdAsync(id);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetByCompanyId(Guid companyId)
        {
            var result = await _userService.GetByCompanyIdAsync(companyId);
            return !result.Success ? BadRequest(result) : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationUser user)
        {
            var result = await _userService.CreateAsync(user);
            return result.Success ? CreatedAtAction(nameof(GetById), new { id = user.userid }, result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ApplicationUser user)
        {
            user.userid = id;
            var result = await _userService.UpdateAsync(user);
            return !result.Success ? BadRequest(result) : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}