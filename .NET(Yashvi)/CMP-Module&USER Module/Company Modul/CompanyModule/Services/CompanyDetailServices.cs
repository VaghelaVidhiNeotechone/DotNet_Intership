using CompanyModule.Interface.Repository;
using CompanyModule.Interface.Services.CompanyDetail;
using CompanyModule.Models.DTO;
using CompanyModule.Models.POCO.Request.CompanyDetail;

namespace CompanyModule.Services
{
    public class CompanyDetailServices : ICompanyDetailServices
    {
        private readonly ICompanyDetailRepository _repository;

        public CompanyDetailServices(ICompanyDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CompanyDetailEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CompanyDetailEntity?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<CompanyDetailEntity> CreateAsync(CompanyDetailEntity company)
        {
            return await _repository.CreateAsync(company);
        }

        public async Task<CompanyDetailEntity> UpdateAsync(CompanyDetailEntity company)
        {
            return await _repository.UpdateAsync(company);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CompanyDetailEntity> AddAsync(CompanyDetailRequest request)
        {
            var company = new CompanyDetailEntity
            {
                companyname = request.companyname,
                address = request.address,
                city = request.city,
                phonenumber = request.phonenumber
            };
            return await _repository.CreateAsync(company);
        }

        public Task GetAllCompaniesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CompanyDetailRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCompanyAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CompanyExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompanyAsync(CompanyDetailEntity company)
        {
            throw new NotImplementedException();
        }

        public Task CreateCompanyAsync(CompanyDetailEntity company)
        {
            throw new NotImplementedException();
        }

        public Task GetCompanyByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}