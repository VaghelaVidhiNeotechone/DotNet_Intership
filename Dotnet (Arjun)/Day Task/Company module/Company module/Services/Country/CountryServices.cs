using AutoMapper;
using Company_module.Domain;
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
        private readonly IUnitOfWork _unitOfWork;

        public CountryServices(
            ICountryRepository repo,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

            if (string.IsNullOrWhiteSpace(request.CountryName))
                throw new ArgumentException("Country name is required");

            var exists = await _repo.CountryNameExistsAsync(request.CountryName);
            if (exists)
                throw new ArgumentException("Country already exists");


            var entity = _mapper.Map<Models.DTO.Country>(request);
            entity.CountryId = Guid.NewGuid();
            entity.Status = Status.Active;
            entity.IsDeleted = false;

            await _repo.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, CountryRequest request)
        {
            var country = await _repo.GetByIdAsync(id);
            if (country == null)
                throw new ArgumentException("Country not found");

            if (string.IsNullOrWhiteSpace(request.CountryName))
                throw new ArgumentException("Country name is required");

            var exists = await _repo
                .CountryNameExistsExceptIdAsync(request.CountryName, id);

            if (exists)
                throw new ArgumentException("Country already exists");

            country.CountryName = request.CountryName;
            country.CountryCode = request.CountryCode;

            _repo.Update(country);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task DeleteAsync(Guid id)
        {
            var country = await _repo.GetByIdAsync(id);
            if (country == null)
                throw new Exception("Country not found");

            _repo.Delete(country);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
