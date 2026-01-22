using CompanyModule.Interface.Repository;
using CompanyModule.Interface.Services.User;
using CompanyModule.Models.DTO;
using CompanyModule.Common.Responses;
using CompanyModule.Models.POCO.Request.Users;

namespace CompanyModule.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ApplicationUser> CreateUserAsync(ApplicationUser user)
        {
            return await _repository.CreateAsync(user);
        }

        public async Task<ApplicationUser> UpdateUserAsync(ApplicationUser user)
        {
            return await _repository.UpdateAsync(user);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ServiceResponse<object>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return ServiceResponse<object>.Ok(result);
        }

        public async Task<ServiceResponse<ApplicationUser>> GetByIdAsync(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            return ServiceResponse<ApplicationUser>.Ok(result);
        }

        public async Task<ServiceResponse<IEnumerable<ApplicationUser>>> GetByCompanyIdAsync(Guid companyId)
        {
            var result = await _repository.GetAllAsync();
            return ServiceResponse<IEnumerable<ApplicationUser>>.Ok(result);
        }

        public async Task<ServiceResponse<ApplicationUser>> CreateAsync(ApplicationUser user)
        {
            var result = await _repository.CreateAsync(user);
            return ServiceResponse<ApplicationUser>.Ok(result);
        }

        public async Task<ServiceResponse<ApplicationUser>> UpdateAsync(ApplicationUser user)
        {
            var result = await _repository.UpdateAsync(user);
            return ServiceResponse<ApplicationUser>.Ok(result);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            return ServiceResponse<bool>.Ok(result);
        }

        public async Task<ServiceResponse<object>> Authenticate(string email, string password)
        {
            return ServiceResponse<object>.Ok(new { token = "dummy-token" });
        }

        public Task Authenticate(AuthenticateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}