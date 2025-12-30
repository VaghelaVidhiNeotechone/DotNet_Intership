using Company_module.Domain.Data;
using Company_module.Domain.Repository;
using Company_module.Interface.Repository;

namespace Company_module.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;

            CompanyDetailRepository = new CompanyDetailRepository(_context);
            CompanyAttachmentRepository = new CompanyAttachmentRepository(_context);
            CountryRepository = new CountryRepository(_context);
            CurrencyRepository = new CurrencyRepository(_context);
        }

        public ICompanyDetailRepository CompanyDetailRepository { get; }
        public ICompanyAttachmentRepository CompanyAttachmentRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public ICurrencyRepository CurrencyRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
