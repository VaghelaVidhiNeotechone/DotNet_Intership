using Company_module.Interface.Repository;
using Company_module.Interface.Services.CompanyDetail;
using Company_module.Models.DTO;
using Company_module.Models.POCO.Request.CompanyDetail;

namespace Company_module.Services.CompanyDetail
{
    public class CompanyAttachmentServices : ICompanyAttachmentServices
    {
        private readonly ICompanyAttachmentRepository _repo;

        public CompanyAttachmentServices(
            ICompanyAttachmentRepository repo)
        {
            _repo = repo;
        }

        public async Task AddCompanyAttachment(
            CompanyAttachmentRequest request)
        {
            var companyExists = await _repo.CompanyExistsAsync(request.companyid);

            if (!companyExists)
            {
                throw new Exception("Invalid CompanyId. Company does not exist.");
            }

            var attachment = new CompanyAttachment
            {
                attachmentid = Guid.NewGuid(),
                companyid = request.companyid,
                filename = request.filename,
                filetype = request.filetype,
                filepath = "uploads/" + request.filename,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false
            };

            await _repo.AddAsync(attachment);
        }

        public async Task<CompanyAttachment> GetAttachmentById(Guid attachmentId)
        {
            return await _repo.GetByIdAsync(attachmentId);
        }

        public async Task<IEnumerable<CompanyAttachment>> GetAllAttachmentsByCompanyId(Guid companyId)
        {
            return await _repo.GetAllByCompanyIdAsync(companyId);
        }

        public async Task UpdateAttachment(CompanyAttachmentRequest request)
        {
            var existing = await _repo.GetByIdAsync(request.attachmentid);
            if (existing != null)
            {
                existing.filename = request.filename;
                existing.filetype = request.filetype;
                existing.filepath = "uploads/" + request.filename;
                await _repo.UpdateAsync(existing);
            }
        }
        
        public async Task DeleteAttachment(Guid attachmentId)
        {
            await _repo.DeleteAsync(attachmentId);
        }
    }
}