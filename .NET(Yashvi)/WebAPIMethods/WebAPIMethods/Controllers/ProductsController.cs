using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Dummy In-Memory List
        private static List<Product> products = new List<Product>()
        {
            new Product(){ Id = 1, Name = "Laptop", Price = 50000 },
            new Product(){ Id = 2, Name = "Mouse", Price = 500 },
        };

        // ============= GET ALL (200) =============
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new ApiResponse<List<Product>>(200, true, "Data fetched successfully", products);
            return Ok(response);
        }

        // ============= GET BY ID (404, 200) =============
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                var error = new ApiResponse<string>(404, false, "Product not found");
                return NotFound(error);
            }

            var response = new ApiResponse<Product>(200, true, "Product found", product);
            return Ok(response);
        }

        // ============= CREATE (201, 400) =============
        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (string.IsNullOrWhiteSpace(p.Name))
            {
                var error = new ApiResponse<string>(400, false, "Name is required");
                return BadRequest(error);
            }

            p.Id = products.Count + 1;
            products.Add(p);

            var response = new ApiResponse<Product>(201, true, "Product created successfully", p);
            return StatusCode(201, response); // Created
        }

        // ============= UPDATE (200, 404) =============
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updated)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                var error = new ApiResponse<string>(404, false, "Product not found");
                return NotFound(error);
            }

            product.Name = updated.Name;
            product.Price = updated.Price;

            var response = new ApiResponse<Product>(200, true, "Product updated successfully", product);
            return Ok(response);
        }

        // ============= DELETE (200, 404) =============
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                var error = new ApiResponse<string>(404, false, "Product not found");
                return NotFound(error);
            }

            products.Remove(product);

            var response = new ApiResponse<string>(200, true, "Product deleted successfully");
            return Ok(response);
        }

        // ============= NO CONTENT (204) =============
        [HttpGet("empty")]
        public IActionResult NoContentExample()
        {
            var response = new ApiResponse<string>(204, true, "No content available");
            return NoContent(); // returns empty response
        }

        // ============= UNAUTHORIZED (401) =============
        [HttpGet("unauthorized")]
        public IActionResult UnauthorizedExample()
        {
            var response = new ApiResponse<string>(401, false, "You must log in");
            return Unauthorized(response);
        }

        // ============= FORBIDDEN (403) =============
        [HttpGet("forbidden")]
        public IActionResult ForbiddenExample()
        {
            var response = new ApiResponse<string>(403, false, "Access denied");
            return StatusCode(403, response);
        }

        // ============= INTERNAL SERVER ERROR (500) =============
        [HttpGet("crash")]
        public IActionResult CrashExample()
        {
            try
            {
                int x = 0;
                int y = 10 / x; // crash here
                return Ok();
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<string>(500, false, "Internal Server Error: " + ex.Message);
                return StatusCode(500, error);
            }
        }
    }
}
