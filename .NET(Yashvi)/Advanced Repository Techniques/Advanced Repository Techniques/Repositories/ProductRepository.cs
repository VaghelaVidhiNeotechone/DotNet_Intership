using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await _context.Products.ToListAsync();

    public async Task<Product?> GetByIdAsync(int id)
        => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

    //public async Task<Product?> GetByNameUsingSpAsync(string name)
    //{
    //    return _context.Products
    //        .FromSqlRaw("EXEC GetProductByName @Name={0}", name)
    //        .AsNoTracking()
    //        .AsEnumerable()       
    //        .FirstOrDefault();
    //}
    public async Task<Product?> GetByNameUsingSpAsync(string name)
    {
        var result = await _context.Database
            .SqlQuery<Product>($"EXEC GetProductByName @Name={name}")
            .AsNoTracking()
            .ToListAsync();

        return result.FirstOrDefault();
    }


    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    // Soft Delete
    public async Task SoftDeleteAsync(int id)
    {
        var product = await _context.Products
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null) return;

        product.IsDeleted = true;
        product.DeletedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }

    //  Restore
    public async Task RestoreAsync(int id)
    {
        var product = await _context.Products
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null) return;

        product.IsDeleted = false;
        product.DeletedAt = null;

        await _context.SaveChangesAsync();
    }

    // Delete
    public async Task HardDeleteAsync(int id)
    {
        var product = await _context.Products
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null) return;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}
