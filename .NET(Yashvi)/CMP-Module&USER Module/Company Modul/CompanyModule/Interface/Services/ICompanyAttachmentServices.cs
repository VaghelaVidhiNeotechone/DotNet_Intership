using CompanyModule.Models.DTO;
using CompanyModule.Models.POCO.Request.CompanyDetail;

namespace CompanyModule.Interface.Services.CompanyDetail
{
    public interface ICompanyAttachmentServices
    {
        Task<IEnumerable<CompanyAttachment>> GetAllAttachmentsAsync();
        Task<CompanyAttachment?> GetAttachmentByIdAsync(Guid id);
        Task<IEnumerable<CompanyAttachment>> GetAttachmentsByCompanyIdAsync(Guid companyId);
        Task<CompanyAttachment> CreateAttachmentAsync(CompanyAttachment attachment);
        Task<CompanyAttachment> UpdateAttachmentAsync(CompanyAttachment attachment);
        Task<bool> DeleteAttachmentAsync(Guid id);
        Task<CompanyAttachment> AddCompanyAttachment(CompanyAttachment attachment);
        Task<CompanyAttachment> GetAttachmentById(Guid id);
        Task<IEnumerable<CompanyAttachment>> GetAllAttachmentsByCompanyId(Guid companyId);
        Task<CompanyAttachment> UpdateAttachment(CompanyAttachment attachment);
        Task<bool> DeleteAttachment(Guid id);
        Task UpdateAttachment(CompanyAttachmentRequest request);
        Task AddCompanyAttachment(CompanyAttachmentRequest request);
    }
}