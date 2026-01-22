using CompanyModule.Models.DTO;
using CompanyModule.Common.Responses;
using CompanyModule.Models.POCO.Request.Users;

namespace CompanyModule.Interface.Services.User
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser?> GetUserByIdAsync(Guid id);
        Task<ApplicationUser> CreateUserAsync(ApplicationUser user);
        Task<ApplicationUser> UpdateUserAsync(ApplicationUser user);
        Task<bool> DeleteUserAsync(Guid id);
        Task<ServiceResponse<object>> GetAllAsync();
        Task<ServiceResponse<ApplicationUser>> GetByIdAsync(Guid id);
        Task<ServiceResponse<IEnumerable<ApplicationUser>>> GetByCompanyIdAsync(Guid companyId);
        Task<ServiceResponse<ApplicationUser>> CreateAsync(ApplicationUser user);
        Task<ServiceResponse<ApplicationUser>> UpdateAsync(ApplicationUser user);
        Task<ServiceResponse<bool>> DeleteAsync(Guid id);
        Task<ServiceResponse<object>> Authenticate(string email, string password);
        Task Authenticate(AuthenticateRequest request);
    }
}