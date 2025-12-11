using Advanced_Repository_Operations___Asynchronous_Programming.Repositories;
using Advanced_Repository_Operations___Asynchronous_Programming.Dtos;
using Advanced_Repository_Operations___Asynchronous_Programming.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sieve.Services;
using Sieve.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced_Repository_Operations___Asynchronous_Programming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _repo;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public ProductsController(IRepository<Product> repo, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _repo = repo;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SieveModel model)
        {
            var productsQuery = _repo.GetAll();

            var filteredQuery = _sieveProcessor.Apply(model, productsQuery);

            var productsList = await filteredQuery.ToListAsync();

            var dtos = _mapper.Map<IEnumerable<ProductDto>>(productsList);

            return Ok(dtos);
        }


        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var products = await _repo.GetAllAsync();
        //    var dtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        //    return Ok(dtos);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repo.AddAsync(product);
            await _repo.SaveChangesAsync();
            var resultDto = _mapper.Map<ProductDto>(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing); 
            _repo.Update(existing);
            await _repo.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _repo.Remove(existing);
            await _repo.SaveChangesAsync();
            return NoContent();
        }
    }
}
        