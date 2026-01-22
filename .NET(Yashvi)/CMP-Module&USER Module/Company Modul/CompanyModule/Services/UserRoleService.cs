using CompanyModule.Interface.Repository;
using CompanyModule.Interface.Services.UserRole;
using CompanyModule.Models.DTO;
using CompanyModule.Common.Responses;
using CompanyModule.Models.POCO.Request.UserRole;

namespace CompanyModule.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _repository;

        public UserRoleService(IUserRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Models.DTO.UserRole>> GetAllUserRolesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Models.DTO.UserRole?> GetUserRoleByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Models.DTO.UserRole> CreateUserRoleAsync(Models.DTO.UserRole userRole)
        {
            return await _repository.CreateAsync(userRole);
        }

        public async Task<Models.DTO.UserRole> UpdateUserRoleAsync(Models.DTO.UserRole userRole)
        {
            return await _repository.UpdateAsync(userRole);
        }

        public async Task<bool> DeleteUserRoleAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ServiceResponse<bool>> Create(Models.DTO.UserRole userRole)
        {
            var result = await _repository.CreateAsync(userRole);
            return ServiceResponse<bool>.Ok(result != null);
        }

        public async Task<ServiceResponse<bool>> Update(Models.DTO.UserRole userRole)
        {
            var result = await _repository.UpdateAsync(userRole);
            return ServiceResponse<bool>.Ok(result != null);
        }

        public async Task<ServiceResponse<bool>> UpdateStatus(Guid id, int status)
        {
            return ServiceResponse<bool>.Ok(true);
        }

        public async Task<ServiceResponse<Models.DTO.UserRole>> GetById(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            return ServiceResponse<Models.DTO.UserRole>.Ok(result);
        }

        public async Task<ServiceResponse<IEnumerable<Models.DTO.UserRole>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return ServiceResponse<IEnumerable<Models.DTO.UserRole>>.Ok(result);
        }

        public async Task<ServiceResponse<object>> GetAllPaginated(int pageNumber, int pageSize)
        {
            return ServiceResponse<object>.Ok(new { });
        }

        public async Task<ServiceResponse<IEnumerable<Models.DTO.UserRole>>> GetAllddlData()
        {
            var result = await _repository.GetAllAsync();
            return ServiceResponse<IEnumerable<Models.DTO.UserRole>>.Ok(result);
        }

        public async Task<ServiceResponse<bool>> RestoreUserRole(Guid id)
        {
            return ServiceResponse<bool>.Ok(true);
        }

        public async Task<ServiceResponse<bool>> Delete(List<Guid> ids)
        {
            return ServiceResponse<bool>.Ok(true);
        }

        public async Task<ServiceResponse<object>> ImportUserRoleFromCsv(object csvData)
        {
            return ServiceResponse<object>.Ok(new { });
        }

        public Task<ServiceResponse<object>> Create(UserRoleRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<object>> Update(UserRoleRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<object>> UpdateStatus(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<object>> GetAllPaginated(UserRoleFilterModel filterModel)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<object>> RestoreUserRole(List<Guid> ids)
        {
            throw new NotImplementedException();
        }
    }
}