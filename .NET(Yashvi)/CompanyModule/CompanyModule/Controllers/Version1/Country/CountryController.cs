using CompanyModule.Interface.Services.Country;
using CompanyModule.Models.POCO.Request.Country;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyModule.Controllers.Version .Country
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryServices _services;

        public CountryController(ICountryServices services)
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
public async Task<IActionResult> Create(CountryRequest request)
{
    if (string.IsNullOrWhiteSpace(request.CountryName))
        return BadRequest("Country name is required");

    await _services.CreateAsync(request);
    return Ok("Country Created Successfully");
}


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CountryRequest request)
        {
            await _services.UpdateAsync(id, request);
            return Ok("Country Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _services.DeleteAsync(id);
            return Ok("Country Deleted Successfully");
        }
    }
}
