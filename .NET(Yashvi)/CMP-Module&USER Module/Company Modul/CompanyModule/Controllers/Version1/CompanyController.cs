using CompanyModule.Interface.Services.CompanyDetail;
using CompanyModule.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CompanyModule.Controllers.Version1
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyDetailServices _companyService;

        public CompanyController(ICompanyDetailServices companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDetailEntity>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDetailEntity>> GetCompany(Guid id)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDetailEntity>> CreateCompany(CompanyDetailEntity company)
        {
            var createdCompany = await _companyService.CreateAsync(company);
            return CreatedAtAction(nameof(GetCompany), new { id = createdCompany.companyid }, createdCompany);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(Guid id, CompanyDetailEntity company)
        {
            if (id != company.companyid)
            {
                return BadRequest();
            }

            var updatedCompany = await _companyService.UpdateAsync(company);
            return Ok(updatedCompany);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            var result = await _companyService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}