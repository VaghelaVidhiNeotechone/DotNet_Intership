using AutoMapper;
using Company_module.Interface.Repository;
using Company_module.Interface.Services.Country;
using Company_module.Models.Enums;
using Company_module.Models.POCO.Request.Country;
using Company_module.Models.POCO.Response.Country;

namespace Company_module.Services.Country
{
    public class CountryServices : ICountryServices
    {
        private readonly ICountryRepository _repo;
        private readonly IMapper _mapper;

        public CountryServices(ICountryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CountryResponse>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<List<CountryResponse>>(data);
        }

        public async Task<CountryResponse?> GetByIdAsync(Guid id)
        {
            var country = await _repo.GetByIdAsync(id);
            return country == null ? null : _mapper.Map<CountryResponse>(country);
        }

        public async Task CreateAsync(CountryRequest request)
        {
            var entity = _mapper.Map<Company_module.Models.DTO.Country>(request);
            entity.CountryId = Guid.NewGuid();
            entity.Status = Status.Active;
            entity.IsDeleted = false;

            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(Guid id, CountryRequest request)
        {
            var country = await _repo.GetByIdAsync(id);
            if (country == null) throw new Exception("Country not found");

            country.CountryCode = request.CountryCode;
            country.CountryName = request.CountryName;

            await _repo.UpdateAsync(country);
        }

        public async Task DeleteAsync(Guid id)
        {
            var country = await _repo.GetByIdAsync(id);
            if (country == null) throw new Exception("Country not found");

            await _repo.DeleteAsync(country);
        }
    }
}
