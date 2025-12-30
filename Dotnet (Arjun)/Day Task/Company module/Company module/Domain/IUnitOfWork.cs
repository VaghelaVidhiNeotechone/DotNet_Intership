using Company_module.Interface.Repository;

namespace Company_module.Domain
{
    public interface IUnitOfWork
    {
        ICompanyDetailRepository CompanyDetailRepository { get; }
        ICompanyAttachmentRepository CompanyAttachmentRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }

        Task<int> SaveChangesAsync();
    }

}
