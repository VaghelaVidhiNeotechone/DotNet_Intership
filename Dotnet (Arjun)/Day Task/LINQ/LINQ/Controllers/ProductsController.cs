using LINQ.Data;
using LINQ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LINQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
                return NotFound("Product not found");

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest("Id mismatch");

            var existingProduct = _context.Products.Find(id);

            if (existingProduct == null)
                return NotFound("Product not found");

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.IsActive = product.IsActive;

            _context.SaveChanges();

            return Ok(existingProduct);
        }



        [HttpGet("active")]
        public IActionResult GetActive()
        {
            var products = _context.Products
                .Where(p => p.IsActive)
                .AsNoTracking()
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price
                })
                .ToList();

            return Ok(products);
        }


        [HttpGet("best")]
        public IActionResult BestQuery()
        {
            var products = _context.Products
                .Where(p => p.IsActive && p.Price > 1000)
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price
                })
                .Skip(0)
                .Take(5)
                .ToList();

            return Ok(products);
        }


    }
}
