using CompanyModule.Models.DTO;
using CompanyModule.Models.POCO.Request.Country;

namespace CompanyModule.Interface.Services.Country
{
    public interface ICountryServices
    {
        Task<IEnumerable<Models.DTO.Country>> GetAllAsync();
        Task<Models.DTO.Country?> GetByIdAsync(Guid id);
        Task<Models.DTO.Country> CreateAsync(Models.DTO.Country country);
        Task<Models.DTO.Country> UpdateAsync(Guid id, Models.DTO.Country country);
        Task<bool> DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, CountryRequest request);
        Task CreateAsync(CountryRequest request);
    }
}