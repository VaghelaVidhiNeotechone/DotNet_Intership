using Microsoft.AspNetCore.Mvc;
using WebApiValidationDemo.Models;
using WebApiValidationDemo.Services;

namespace WebApiValidationDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // POST api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _service.Add(dto);
            return Ok(product);
        }

        // GET api/products/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // GET api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        // GET api/products/category/mobile
        [HttpGet("category/{category}")]
        public IActionResult GetByCategory(string category)
        {
            return Ok(_service.GetByCategory(category));
        }

        // GET api/products/search/sam
        [HttpGet("search/{name:minlength(3)}")]
        public IActionResult Search(string name)
        {
            return Ok(_service.Search(name));
        }
    }
}
