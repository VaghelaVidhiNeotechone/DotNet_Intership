using Company_module.Models.DTO;

namespace Company_module.Interface.Repository
{
    public interface ICompanyDetailRepository
    {
        Task AddAsync(CompanyDetailEntity entity);
        Task<List<CompanyDetailEntity>> GetAllAsync();
        Task<CompanyDetailEntity> GetByIdAsync(Guid companyId);
        Task UpdateAsync(CompanyDetailEntity entity);
        Task DeleteAsync(Guid companyId);
    }
}
