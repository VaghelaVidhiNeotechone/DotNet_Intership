using System.Collections.Generic;
using BankManagement.Models;

namespace BankManagement.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        Account GetById(int id);
        void Add(Account account);
        void Update(Account account);
        void Delete(int id);
        void Save();
    }
}
