using CompanyModule.Models.DTO;

namespace CompanyModule.Interface.Repository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync();
        Task<Country?> GetByIdAsync(Guid id);
        Task<Country> CreateAsync(Country entity);
        Task<Country> UpdateAsync(Country entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}