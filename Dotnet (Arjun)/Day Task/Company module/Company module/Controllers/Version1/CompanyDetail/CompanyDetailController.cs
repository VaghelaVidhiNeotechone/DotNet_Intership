using Company_module.Interface.Services.CompanyDetail;
using Company_module.Models.POCO.Request.CompanyDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company_module.Controllers.Version1.CompanyDetail
{
    [ApiController]
    [Route("api/v1/company-detail")]
    public class CompanyDetailController : ControllerBase
    {
        private readonly ICompanyDetailServices _service;

        public CompanyDetailController(ICompanyDetailServices service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CompanyDetailRequest request)
        {
            try
            {
                await _service.AddAsync(request);
                return Ok("Company Detail Created Successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound("Company not found");

            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update(CompanyDetailRequest request)
        {
            try
            {
                await _service.AddAsync(request);
                return Ok("Company Detail Created Successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok("Company Detail Deleted Successfully");
        }
    }


}
