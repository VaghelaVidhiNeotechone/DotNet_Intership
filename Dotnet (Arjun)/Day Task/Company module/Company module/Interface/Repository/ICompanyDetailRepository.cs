using Company_module.Models.DTO;

namespace Company_module.Interface.Repository
{
    public interface ICompanyDetailRepository
    {
        Task AddAsync(CompanyDetailEntity entity);
        Task<List<CompanyDetailEntity>> GetAllAsync();
        Task<CompanyDetailEntity> GetByIdAsync(Guid companyId);
        void Update(CompanyDetailEntity entity);
        void Delete(CompanyDetailEntity entity);


        Task<bool> CountryExistsAsync(Guid countryId);
        Task<bool> CurrencyExistsAsync(Guid currencyId);
    }
}
