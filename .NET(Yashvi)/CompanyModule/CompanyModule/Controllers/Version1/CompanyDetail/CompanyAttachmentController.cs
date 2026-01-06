using CompanyModule.Interface.Services.CompanyDetail;
using CompanyModule.Models.POCO.Request.CompanyDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyModule.Controllers.Version1.CompanyDetail
{
    [ApiController]
    [Route("api/v1/company-attachment")]
    public class CompanyAttachmentController : ControllerBase
    {
        private readonly ICompanyAttachmentServices _attachmentServices;

        public CompanyAttachmentController(ICompanyAttachmentServices attachmentServices)
        {
            _attachmentServices = attachmentServices;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompanyAttachmentRequest request)
        {
            await _attachmentServices.AddCompanyAttachment(request);
            return Ok("Attachment Added Successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var data = await _attachmentServices.GetAttachmentById(id);
            return Ok(data);
        }

        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetAllByCompany(Guid companyId)
        {
            var data = await _attachmentServices.GetAllAttachmentsByCompanyId(companyId);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CompanyAttachmentRequest request)
        {
            await _attachmentServices.UpdateAttachment(request);
            return Ok("Attachment Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _attachmentServices.DeleteAttachment(id);
            return Ok("Attachment Deleted Successfully");
        }
    }
}
