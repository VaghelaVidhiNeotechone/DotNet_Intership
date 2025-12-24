using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;

    public ProductsController(IProductRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _repo.GetByIdAsync(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    //[HttpGet("by-name-sp/{name}")]
    //public async Task<IActionResult> GetByName(string name)
    //{
    //    var product = await _repo.GetByNameUsingSpAsync(name);
    //    if (product == null)
    //        return NotFound($"Product '{name}' not found");

    //    return Ok(product);
    //}
    [HttpGet("by-name-sp/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var product = await _repo.GetByNameUsingSpAsync(name);

        if (product == null)
            return NotFound();

        return Ok(product);
    }



    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _repo.AddAsync(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        product.Id = id;
        await _repo.UpdateAsync(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        await _repo.SoftDeleteAsync(id);
        return NoContent();
    }


    [HttpPost("{id}/restore")]
    public async Task<IActionResult> Restore(int id)
    {
        await _repo.RestoreAsync(id);
        return NoContent();
    }

    [HttpDelete("{id}/hard")]
    public async Task<IActionResult> HardDelete(int id)
    {
        await _repo.HardDeleteAsync(id);
        return NoContent();
    }
}
