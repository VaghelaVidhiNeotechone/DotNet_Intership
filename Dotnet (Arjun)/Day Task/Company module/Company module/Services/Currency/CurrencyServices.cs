using AutoMapper;
using Company_module.Domain;
using Company_module.Interface.Repository;
using Company_module.Interface.Services.Currency;
using Company_module.Models.DTO;
using Company_module.Models.Enums;
using Company_module.Models.POCO.Request.Currency;
using Company_module.Models.POCO.Response.Currency;

namespace Company_module.Services.Currency
{
    public class CurrencyServices : ICurrencyServices
    {
        private readonly ICurrencyRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CurrencyServices(ICurrencyRepository repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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
                throw new ArgumentException("Currency name is required");

            var exists = await _repo.CurrencyNameExistsAsync(request.CurrencyName);
            if (exists)
                throw new ArgumentException("Currency already exists");


            var entity = _mapper.Map<Company_module.Models.DTO.Currency>(request);
            entity.CurrencyId = Guid.NewGuid();
            entity.Status = Status.Active;
            entity.IsDeleted = false;

            await _repo.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, CurrencyRequest request)
        {
            var currency = await _repo.GetByIdAsync(id);
            if (currency == null)
                throw new ArgumentException("Currency not found");

            if (string.IsNullOrWhiteSpace(request.CurrencyName))
                throw new ArgumentException("Currency name is required");

            var exists = await _repo
                .CurrencyNameExistsExceptIdAsync(request.CurrencyName, id);

            if (exists)
                throw new ArgumentException("Currency already exists");

            currency.CurrencyName = request.CurrencyName;

            _repo.Update(currency);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task DeleteAsync(Guid id)
        {
            var currency = await _repo.GetByIdAsync(id);
            if (currency == null)
                throw new Exception("Currency not found");

            _repo.Delete(currency);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
