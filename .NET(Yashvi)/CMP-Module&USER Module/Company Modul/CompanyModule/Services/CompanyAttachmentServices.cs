using CompanyModule.Interface.Repository;
using CompanyModule.Interface.Services.CompanyDetail;
using CompanyModule.Models.DTO;
using CompanyModule.Models.POCO.Request.CompanyDetail;

namespace CompanyModule.Services
{
    public class CompanyAttachmentServices : ICompanyAttachmentServices
    {
        private readonly ICompanyAttachmentRepository _repository;

        public CompanyAttachmentServices(ICompanyAttachmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CompanyAttachment>> GetAllAttachmentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CompanyAttachment?> GetAttachmentByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CompanyAttachment>> GetAttachmentsByCompanyIdAsync(Guid companyId)
        {
            return await _repository.GetByCompanyIdAsync(companyId);
        }

        public async Task<CompanyAttachment> CreateAttachmentAsync(CompanyAttachment attachment)
        {
            return await _repository.CreateAsync(attachment);
        }

        public async Task<CompanyAttachment> UpdateAttachmentAsync(CompanyAttachment attachment)
        {
            return await _repository.UpdateAsync(attachment);
        }

        public async Task<bool> DeleteAttachmentAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CompanyAttachment> AddCompanyAttachment(CompanyAttachment attachment)
        {
            return await _repository.CreateAsync(attachment);
        }

        public async Task<CompanyAttachment> GetAttachmentById(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CompanyAttachment>> GetAllAttachmentsByCompanyId(Guid companyId)
        {
            return await _repository.GetByCompanyIdAsync(companyId);
        }

        public async Task<CompanyAttachment> UpdateAttachment(CompanyAttachment attachment)
        {
            return await _repository.UpdateAsync(attachment);
        }

        public async Task<bool> DeleteAttachment(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task UpdateAttachment(CompanyAttachmentRequest request)
        {
            throw new NotImplementedException();
        }

        public Task AddCompanyAttachment(CompanyAttachmentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}