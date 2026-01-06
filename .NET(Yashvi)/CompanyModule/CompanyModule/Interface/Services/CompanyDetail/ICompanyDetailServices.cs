using CompanyModule.Models.POCO.Request.CompanyDetail;
using CompanyModule.Models.POCO.Response.CompanyDetail;

namespace CompanyModule.Interface.Services.CompanyDetail
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
