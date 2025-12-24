public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);

    Task<Product?> GetByNameUsingSpAsync(string name); 

    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task SoftDeleteAsync(int id);
    Task RestoreAsync(int id);
    Task HardDeleteAsync(int id);
}
