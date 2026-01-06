using AutoMapper;
using CompanyModule.Domain.Data;
using CompanyModule.Interface.Repository;
using CompanyModule.Interface.Services.CompanyDetail;
using CompanyModule.Models.DTO;
using CompanyModule.Models.Enums;
using CompanyModule.Models.POCO.Request.CompanyDetail;
using CompanyModule.Models.POCO.Response.CompanyDetail;
using Microsoft.EntityFrameworkCore;

namespace CompanyModule.Services.CompanyDetail
{
    public class CompanyDetailServices : ICompanyDetailServices
    {
        private readonly ICompanyDetailRepository _repo;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public CompanyDetailServices(
            ICompanyDetailRepository repo,
            IMapper mapper,
            ApplicationContext context)
        {
            _repo = repo;
            _mapper = mapper;
            _context = context;
        }

        public async Task AddAsync(CompanyDetailRequest request)
        {
            
            var country = await _context.Countries
                .FirstOrDefaultAsync(x =>
                    x.CountryName == request.countryname && !x.IsDeleted);

            if (country == null)
            {
                country = new CompanyModule.Models.DTO.Country
                {
                    CountryId = Guid.NewGuid(),
                    CountryName = request.countryname,
                    CountryCode = request.countryname.Substring(0, 2).ToUpper(),
                    Status = Status.Active,
                    IsDeleted = false
                };

                await _context.Countries.AddAsync(country);
                await _context.SaveChangesAsync();
            }

           
            var currency = await _context.Currencies
                .FirstOrDefaultAsync(x =>
                    x.CurrencyName == request.currencyname && !x.IsDeleted);

            if (currency == null)
            {
                currency = new CompanyModule.Models.DTO.Currency
                {
                    CurrencyId = Guid.NewGuid(),
                    CurrencyName = request.currencyname,
                    Status = Status.Active,
                    IsDeleted = false
                };

                await _context.Currencies.AddAsync(currency);
                await _context.SaveChangesAsync();
            }

            // ===== COMPANY DETAIL =====
            var entity = _mapper.Map<CompanyDetailEntity>(request);

            entity.companyid = Guid.NewGuid();
            entity.countryid = country.CountryId;
            entity.currencyid = currency.CurrencyId;

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
