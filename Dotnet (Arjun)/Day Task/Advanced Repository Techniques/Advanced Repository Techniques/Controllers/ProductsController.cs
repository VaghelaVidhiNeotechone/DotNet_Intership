using Advanced_Repository_Techniques.Dtos;
using Advanced_Repository_Techniques.Models;
using Advanced_Repository_Techniques.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advanced_Repository_Techniques.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _repo;
        private readonly IMapper _mapper;

        public ProductsController(IRepository<Product> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _repo.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(dtos);
        }

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

            await _repo.SoftDeleteAsync(existing);
            await _repo.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{id}/restore")]
        public async Task<IActionResult> Restore(int id)
        {
            var existing = await _repo.GetByIdIncludingDeletedAsync(id);
            if (existing == null) return NotFound();

            await _repo.RestoreAsync(existing);
            await _repo.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}/hard")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var existing = await _repo.GetByIdIncludingDeletedAsync(id);
            if (existing == null) return NotFound();

            await _repo.HardDeleteAsync(existing);
            await _repo.SaveChangesAsync();
            return NoContent();
        }






        [HttpGet("by-name-sp/{name}")]
        public async Task<IActionResult> GetByNameSP(string name)
        {
            var products = await ((Repository<Product>)_repo)
                .GetProductsByNameSP(name);

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

    }
}
