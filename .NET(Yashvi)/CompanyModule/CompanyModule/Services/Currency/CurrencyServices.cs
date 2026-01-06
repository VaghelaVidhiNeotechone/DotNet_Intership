using AutoMapper;
using CompanyModule.Interface.Repository;
using CompanyModule.Interface.Services.Currency;
using CompanyModule.Models.Enums;
using CompanyModule.Models.POCO.Request.Currency;
using CompanyModule.Models.POCO.Response.Currency;

namespace CompanyModule.Services.Currency
{
    public class CurrencyServices : ICurrencyServices
    {
        private readonly ICurrencyRepository _repo;
        private readonly IMapper _mapper;

        public CurrencyServices(ICurrencyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CurrencyResponse>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<List<CurrencyResponse>>(data);
        }

        public async Task<CurrencyResponse?> GetByIdAsync(Guid id)
        {
            var currency = await _repo.GetByIdAsync(id);
            return currency == null ? null : _mapper.Map<CurrencyResponse>(currency);
        }

        public async Task CreateAsync(CurrencyRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CurrencyName))
            {
                throw new ArgumentException("Please enter currency name");
            }

            var entity = _mapper.Map<Models.DTO.Currency>(request);

            entity.CurrencyId = Guid.NewGuid();
            entity.CurrencyName = request.CurrencyName.Trim();
            entity.Status = Status.Active;
            entity.IsDeleted = false;

            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(Guid id, CurrencyRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CurrencyName))
            {
                throw new ArgumentException("Please enter currency name");
            }

            var currency = await _repo.GetByIdAsync(id);
            if (currency == null)
                throw new Exception("Currency not found");

            currency.CurrencyName = request.CurrencyName.Trim();
            await _repo.UpdateAsync(currency);
        }

        public async Task DeleteAsync(Guid id)
        {
            var currency = await _repo.GetByIdAsync(id);
            if (currency == null)
                throw new Exception("Currency not found");

            await _repo.DeleteAsync(currency);
        }
    }
}
