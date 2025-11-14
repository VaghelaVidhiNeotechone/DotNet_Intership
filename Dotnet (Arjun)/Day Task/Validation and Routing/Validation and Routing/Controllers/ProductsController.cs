using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Validation_and_Routing.Models;

namespace Validation_and_Routing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        // GET: api/products
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound("Product not found");
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Validation Error Return
            }

            product.Id = products.Count + 1;
            products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/products/5
        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existing = products.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound("Product not found");

            existing.Name = product.Name;
            existing.Price = product.Price;
            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound("Product not found");

            products.Remove(product);
            return NoContent();
        }
    }
}
