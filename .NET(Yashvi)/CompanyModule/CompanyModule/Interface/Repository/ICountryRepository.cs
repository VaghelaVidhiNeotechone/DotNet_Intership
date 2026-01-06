using CompanyModule.Models.DTO;

namespace CompanyModule.Interface.Repository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync();
        Task<Country?> GetByIdAsync(Guid id);
        Task AddAsync(Country country);
        Task UpdateAsync(Country country);
        Task DeleteAsync(Country country);
    }
}
