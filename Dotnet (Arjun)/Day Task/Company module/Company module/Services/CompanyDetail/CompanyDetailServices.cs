using Company_module.Models.POCO.Request.CompanyDetail;
using Company_module.Models.DTO;
using Company_module.Interface.Repository;
using AutoMapper;
using Company_module.Interface.Services.CompanyDetail;
using Company_module.Models.POCO.Response.CompanyDetail;

namespace Company_module.Services.CompanyDetail
{
    public class CompanyDetailServices : ICompanyDetailServices
    {
        private readonly ICompanyDetailRepository _repo;
        private readonly IMapper _mapper;

        public CompanyDetailServices(
            ICompanyDetailRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task AddAsync(CompanyDetailRequest request)
        {
            var entity = _mapper.Map<CompanyDetailEntity>(request);
            entity.companyid = Guid.NewGuid();
            await _repo.AddAsync(entity);
        }

        public async Task<List<CompanyDetailResponse>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<List<CompanyDetailResponse>>(data);
        }

        public async Task<CompanyDetailResponse> GetByIdAsync(Guid companyId)
        {
            var data = await _repo.GetByIdAsync(companyId);
            return _mapper.Map<CompanyDetailResponse>(data);
        }

        public async Task UpdateAsync(CompanyDetailRequest request)
        {
            var entity = await _repo.GetByIdAsync(request.companyid);
            if (entity == null) return;

            _mapper.Map(request, entity);
            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid companyId)
        {
            await _repo.DeleteAsync(companyId);
        }
    }

}
