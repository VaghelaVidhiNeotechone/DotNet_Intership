using AutoMapper;
using Company_module.Interface.Repository;
using Company_module.Interface.Services.Currency;
using Company_module.Models.Enums;
using Company_module.Models.POCO.Request.Currency;
using Company_module.Models.POCO.Response.Currency;

namespace Company_module.Services.Currency
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
            var entity = _mapper.Map<Company_module.Models.DTO.Currency>(request);
            entity.CurrencyId = Guid.NewGuid();
            entity.Status = Status.Active;
            entity.IsDeleted = false;

            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(Guid id, CurrencyRequest request)
        {
            var currency = await _repo.GetByIdAsync(id);
            if (currency == null)
                throw new Exception("Currency not found");

            currency.CurrencyName = request.CurrencyName;
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
