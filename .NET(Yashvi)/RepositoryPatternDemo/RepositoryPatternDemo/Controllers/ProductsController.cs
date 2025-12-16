using Microsoft.AspNetCore.Mvc;
using RepositoryPatternDemo.Models;
using RepositoryPatternDemo.Repositories;


namespace RepositoryPatternDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;


        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            _repository.Add(product);
            _repository.Save();
            return Ok(product);
        }


        [HttpPut]
        public IActionResult Update(Product product)
        {
            _repository.Update(product);
            _repository.Save();
            return Ok(product);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return Ok();
        }
    }
}