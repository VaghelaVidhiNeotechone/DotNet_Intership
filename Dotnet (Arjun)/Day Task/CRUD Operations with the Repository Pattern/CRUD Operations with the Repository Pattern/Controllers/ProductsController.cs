using AutoMapper;
using CRUD_Operations_with_the_Repository_Pattern.Dtos;
using CRUD_Operations_with_the_Repository_Pattern.Models;
using CRUD_Operations_with_the_Repository_Pattern.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operations_with_the_Repository_Pattern.Controllers
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

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = _mapper.Map<Product>(dto);

            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();

            return Ok(_mapper.Map<ProductDto>(entity));
        }

        // READ (all)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        // READ (by ID)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return NotFound();

            return Ok(_mapper.Map<ProductDto>(product));
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);

            _repo.Update(existing);
            await _repo.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
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
