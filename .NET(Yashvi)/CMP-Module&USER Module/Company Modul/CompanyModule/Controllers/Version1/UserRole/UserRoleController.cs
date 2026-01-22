using CompanyModule.Interface.Services.UserRole;
using CompanyModule.Models.POCO.Request.UserRole;
using CompanyModule.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CompanyModule.Controllers.Base;
using Asp.Versioning;

namespace CompanyModule.Controllers.Version1.UserRole
{
   
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class UserRoleController : BaseController
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost]
        [Route(APIRouteTemplate.UserRoleRoutes.Create)]
        public async Task<IActionResult> Create(UserRoleRequest request)
        {
            return GenerateBaseResponse(await _userRoleService.Create(request));
        }

   

        [HttpPut]
        [Route(APIRouteTemplate.UserRoleRoutes.Update)]
        public async Task<IActionResult> Update(UserRoleRequest request)
        {
            return GenerateBaseResponse(await _userRoleService.Update(request));
        }

        [HttpPut]
        [Route(APIRouteTemplate.UserRoleRoutes.UpdateStatus)]
        public async Task<IActionResult> UpdateStatus([FromRoute(Name = "id")] Guid id)
        {
            return GenerateBaseResponse(await _userRoleService.UpdateStatus(id));
        }

        [HttpGet]
        [Route(APIRouteTemplate.UserRoleRoutes.GetById)]
        public async Task<IActionResult> GetById([FromRoute(Name = "id")] Guid id)
        {
            return GenerateBaseResponse(await _userRoleService.GetById(id));
        }

        [HttpGet]
        [Route(APIRouteTemplate.UserRoleRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return GenerateBaseResponse(await _userRoleService.GetAll());
        }

        [HttpPost]
        [Route(APIRouteTemplate.UserRoleRoutes.GetAllPaginated)]
        public async Task<IActionResult> GetAllPaginated(UserRoleFilterModel filterModel)
        {
            return GenerateBaseResponse(await _userRoleService.GetAllPaginated(filterModel));
        }

        [HttpGet]
        [Route(APIRouteTemplate.UserRoleRoutes.GetAllddlData)]
        public async Task<IActionResult> GetAllddlData()
        {
            return GenerateBaseResponse(await _userRoleService.GetAllddlData());
        }
        [HttpPost]
        [AllowAnonymous]
        [Route(APIRouteTemplate.UserRoleRoutes.Restore)]
        public async Task<IActionResult> Restore([FromBody] List<Guid> ids)
        {
            var response = await _userRoleService.RestoreUserRole(ids);
            return GenerateBaseResponse(response);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route(APIRouteTemplate.UserRoleRoutes.DeleteAll)]
        public async Task<IActionResult> DeleteAll([FromBody] List<Guid> ids)
        {
            var response = await _userRoleService.Delete(ids);
            return GenerateBaseResponse(response);
        }
        [HttpPost]
        [Route(APIRouteTemplate.UserRoleRoutes.Import)]
        public async Task<IActionResult> Import(IFormFile file)
        {
            return GenerateBaseResponse(await _userRoleService.ImportUserRoleFromCsv(file));
        }
    }
}
