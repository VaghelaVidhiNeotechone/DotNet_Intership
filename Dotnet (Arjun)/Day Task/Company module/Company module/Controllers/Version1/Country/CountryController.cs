using Company_module.Interface.Services.Country;
using Company_module.Models.POCO.Request.Country;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_module.Controllers.Version1.Country
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
