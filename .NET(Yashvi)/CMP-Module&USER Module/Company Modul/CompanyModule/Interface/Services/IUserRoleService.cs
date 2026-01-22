using CompanyModule.Models.DTO;
using CompanyModule.Common.Responses;
using CompanyModule.Models.POCO.Request.UserRole;

namespace CompanyModule.Interface.Services.UserRole
{
    public interface IUserRoleService
    {
        Task<IEnumerable<Models.DTO.UserRole>> GetAllUserRolesAsync();
        Task<Models.DTO.UserRole?> GetUserRoleByIdAsync(Guid id);
        Task<Models.DTO.UserRole> CreateUserRoleAsync(Models.DTO.UserRole userRole);
        Task<Models.DTO.UserRole> UpdateUserRoleAsync(Models.DTO.UserRole userRole);
        Task<bool> DeleteUserRoleAsync(Guid id);
        Task<ServiceResponse<bool>> Create(Models.DTO.UserRole userRole);
        Task<ServiceResponse<bool>> Update(Models.DTO.UserRole userRole);
        Task<ServiceResponse<bool>> UpdateStatus(Guid id, int status);
        Task<ServiceResponse<Models.DTO.UserRole>> GetById(Guid id);
        Task<ServiceResponse<IEnumerable<Models.DTO.UserRole>>> GetAll();
        Task<ServiceResponse<object>> GetAllPaginated(int pageNumber, int pageSize);
        Task<ServiceResponse<IEnumerable<Models.DTO.UserRole>>> GetAllddlData();
        Task<ServiceResponse<bool>> RestoreUserRole(Guid id);
        Task<ServiceResponse<bool>> Delete(List<Guid> ids);
        Task<ServiceResponse<object>> ImportUserRoleFromCsv(object csvData);
        Task<ServiceResponse<object>> Create(UserRoleRequest request);
        Task<ServiceResponse<object>> Update(UserRoleRequest request);
        Task<ServiceResponse<object>> UpdateStatus(Guid id);
        Task<ServiceResponse<object>> GetAllPaginated(UserRoleFilterModel filterModel);
        Task<ServiceResponse<object>> RestoreUserRole(List<Guid> ids);
    }
}