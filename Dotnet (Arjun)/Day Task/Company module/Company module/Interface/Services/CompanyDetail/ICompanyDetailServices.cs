using Company_module.Models.POCO.Request.CompanyDetail;
using Company_module.Models.POCO.Response.CompanyDetail;

namespace Company_module.Interface.Services.CompanyDetail
{
    public interface ICompanyDetailServices
    {
        Task AddAsync(CompanyDetailRequest request);
        Task<List<CompanyDetailResponse>> GetAllAsync();
        Task<CompanyDetailResponse> GetByIdAsync(Guid companyId);
        Task UpdateAsync(CompanyDetailRequest request);
        Task DeleteAsync(Guid companyId);
    }
}
