using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GenericResponseDemo.Models;

namespace GenericResponseDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // ========================
        // GET Methods
        // ========================

        // 200 OK
        [HttpGet("success")]
        public IActionResult GetSuccess()
        {
            var response = new GenericResponse<string>
            {
                StatusCode = 200,
                Message = "Success",
                Data = "This is successful response"
            };
            return Ok(response);
        }

        // 404 Not Found
        [HttpGet("notfound")]
        public IActionResult GetNotFound()
        {
            var response = new GenericResponse<string>
            {
                StatusCode = 404,
                Message = "Data Not Found",
                Data = null
            };
            return NotFound(response);
        }

        // ========================
        // POST Methods
        // ========================

        // 201 Created
        [HttpPost("create")]
        public IActionResult CreateItem([FromBody] string value)
        {
            var response = new GenericResponse<string>
            {
                StatusCode = 201,
                Message = "Resource Created Successfully",
                Data = value
            };
            return StatusCode(201, response);
        }

        // 400 Bad Request
        [HttpPost("badrequest")]
        public IActionResult BadRequestExample()
        {
            var response = new GenericResponse<string>
            {
                StatusCode = 400,
                Message = "Bad Request",
                Data = null
            };
            return BadRequest(response);
        }

        // ========================
        // PUT Methods
        // ========================

        // 200 OK (update)
        [HttpPut("update")]
        public IActionResult UpdateItem([FromBody] string value)
        {
            var response = new GenericResponse<string>
            {
                StatusCode = 200,
                Message = "Resource Updated Successfully",
                Data = value
            };
            return Ok(response);
        }

        // 404 Not Found (update)
        [HttpPut("update-notfound")]
        public IActionResult UpdateNotFound()
        {
            var response = new GenericResponse<string>
            {
                StatusCode = 404,
                Message = "Resource Not Found",
                Data = null
            };
            return NotFound(response);
        }

        // ========================
        // DELETE Methods
        // ========================

        // 200 OK (delete)
        [HttpDelete("delete")]
        public IActionResult DeleteItem()
        {
            var response = new GenericResponse<string>
            {
                StatusCode = 200,
                Message = "Resource Deleted Successfully",
                Data = null
            };
            return Ok(response);
        }

        // 404 Not Found (delete)
        [HttpDelete("delete-notfound")]
        public IActionResult DeleteNotFound()
        {
            var response = new GenericResponse<string>
            {
                StatusCode = 404,
                Message = "Resource Not Found",
                Data = null
            };
            return NotFound(response);
        }

        // ========================
        // Server Error Example
        // ========================

        // 500 Internal Server Error
        [HttpGet("error")]
        public IActionResult GetError()
        {
            var response = new GenericResponse<string>
            {
                StatusCode = 500,
                Message = "Internal Server Error",
                Data = null
            };
            return StatusCode(500, response);
        }
    }
}
