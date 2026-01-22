using CompanyModule.Common.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyModule.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult GenerateBaseResponse<T>(ServiceResponse<T> response)
        {
            if (response == null)
                return BadRequest("Invalid response");

            if (!response.Success)
                return StatusCode((int)response.StatusCode, response);

            return Ok(response);
        }
    }
}
