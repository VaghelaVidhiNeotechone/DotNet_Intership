using Company_module.Models.POCO.Request.CompanyDetail;
using Company_module.Models.DTO;
using Company_module.Interface.Repository;
using AutoMapper;
using Company_module.Interface.Services.CompanyDetail;
using Company_module.Models.POCO.Response.CompanyDetail;
using Company_module.Domain;

namespace Company_module.Services.CompanyDetail
{
    public class CompanyDetailServices : ICompanyDetailServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyDetailServices(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(CompanyDetailRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CountryName))
                throw new ArgumentException("Country is required");

            var countryId = await _unitOfWork.CountryRepository
                .GetCountryIdByNameAsync(request.CountryName);

            if (countryId == null)
                throw new ArgumentException("Invalid Country");

            if (string.IsNullOrWhiteSpace(request.CurrencyName))
                throw new ArgumentException("Currency is required");

            var currencyId = await _unitOfWork.CurrencyRepository
                .GetCurrencyIdByNameAsync(request.CurrencyName);

            if (currencyId == null)
                throw new ArgumentException("Invalid Currency");

            var entity = _mapper.Map<CompanyDetailEntity>(request);

            entity.companyid = Guid.NewGuid();
            entity.countryid = countryId.Value;
            entity.currencyid = currencyId.Value;

            await _unitOfWork.CompanyDetailRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<CompanyDetailResponse>> GetAllAsync()
        {
            var data = await _unitOfWork.CompanyDetailRepository.GetAllAsync();
            return _mapper.Map<List<CompanyDetailResponse>>(data);
        }

        public async Task<CompanyDetailResponse> GetByIdAsync(Guid companyId)
        {
            var data = await _unitOfWork.CompanyDetailRepository.GetByIdAsync(companyId);

            if (data == null)
                throw new KeyNotFoundException("Company not found");

            return _mapper.Map<CompanyDetailResponse>(data);
        }


        public async Task UpdateAsync(CompanyDetailRequest request)
        {
            var entity = await _unitOfWork.CompanyDetailRepository
                                .GetByIdAsync(request.companyid);

            if (entity == null)
                throw new KeyNotFoundException("Company not found");

            if (string.IsNullOrWhiteSpace(request.CountryName))
                throw new ArgumentException("Country is required");

            var countryId = await _unitOfWork.CountryRepository
                .GetCountryIdByNameAsync(request.CountryName);

            if (countryId == null)
                throw new ArgumentException("Invalid Country");

            if (string.IsNullOrWhiteSpace(request.CurrencyName))
                throw new ArgumentException("Currency is required");

            var currencyId = await _unitOfWork.CurrencyRepository
                .GetCurrencyIdByNameAsync(request.CurrencyName);

            if (currencyId == null)
                throw new ArgumentException("Invalid Currency");

            _mapper.Map(request, entity);

            entity.countryid = countryId.Value;
            entity.currencyid = currencyId.Value;

            _unitOfWork.CompanyDetailRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid companyId)
        {
            var entity = await _unitOfWork.CompanyDetailRepository
                .GetByIdAsync(companyId);

            if (entity == null)
                throw new ArgumentException("Company not found");

            _unitOfWork.CompanyDetailRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }

    }

}
