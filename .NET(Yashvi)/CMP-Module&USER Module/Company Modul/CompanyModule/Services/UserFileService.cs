using CompanyModule.Interface.Repository;
using CompanyModule.Interface.Services;
using CompanyModule.Models.DTO;

namespace CompanyModule.Services
{
    public class UserFileService : IUserFileService
    {
        private readonly IUserFileRepository _repository;

        public UserFileService(IUserFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserFile>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UserFile?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UserFile>> GetByUserIdAsync(Guid userId)
        {
            return await _repository.GetByUserIdAsync(userId);
        }

        public async Task<UserFile> CreateAsync(UserFile userFile)
        {
            return await _repository.CreateAsync(userFile);
        }

        public async Task<UserFile> UpdateAsync(UserFile userFile)
        {
            return await _repository.UpdateAsync(userFile);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}