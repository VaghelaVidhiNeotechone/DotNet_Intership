using Company_module.Interface.Services.Currency;
using Company_module.Models.POCO.Request.Currency;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_module.Controllers.Version1.Currency
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyServices _services;

        public CurrencyController(ICurrencyServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _services.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CurrencyRequest request)
        {
            try
            {
                await _services.CreateAsync(request);
                return Ok("Currency created successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CurrencyRequest request)
        {
            try
            {
                await _services.UpdateAsync(id, request);
                return Ok("Currency updated successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _services.DeleteAsync(id);
            return Ok("Currency Deleted Successfully");
        }
    }
}
