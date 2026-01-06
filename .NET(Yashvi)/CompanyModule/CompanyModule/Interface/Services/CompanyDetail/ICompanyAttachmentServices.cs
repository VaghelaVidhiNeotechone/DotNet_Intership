using CompanyModule.Models.DTO;
using CompanyModule.Models.POCO.Request.CompanyDetail;

namespace CompanyModule.Interface.Services.CompanyDetail
{
    public interface ICompanyAttachmentServices
    {
        Task AddCompanyAttachment(CompanyAttachmentRequest request);
        Task<CompanyAttachment> GetAttachmentById(Guid attachmentId);
        Task<IEnumerable<CompanyAttachment>> GetAllAttachmentsByCompanyId(Guid companyId);
        Task UpdateAttachment(CompanyAttachmentRequest request);
        Task DeleteAttachment(Guid attachmentId);
    }
}
