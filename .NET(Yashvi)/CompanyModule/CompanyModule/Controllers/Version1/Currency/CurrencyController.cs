using CompanyModule.Interface.Services.Currency;
using CompanyModule.Models.POCO.Request.Currency;
using Microsoft.AspNetCore.Mvc;

namespace CompanyModule.Controllers.Version1.Currency
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
            if (data == null) return NotFound("Currency not found");
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CurrencyRequest request)
        {
            
            if (string.IsNullOrWhiteSpace(request.CurrencyName))
            {
                return BadRequest("Please enter currency name");
            }

            await _services.CreateAsync(request);
            return Ok("Currency Created Successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CurrencyRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CurrencyName))
            {
                return BadRequest("Please enter currency name");
            }

            await _services.UpdateAsync(id, request);
            return Ok("Currency Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _services.DeleteAsync(id);
            return Ok("Currency Deleted Successfully");
        }
    }
}
