using BankManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankManagement.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAll() => _context.Accounts.ToList();

        public Account GetById(int id) => _context.Accounts.Find(id);

        public void Add(Account account)
        {
            _context.Accounts.Add(account);
        }

        public void Update(Account account)
        {
            _context.Accounts.Update(account);
        }

        public void Delete(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account != null)
                _context.Accounts.Remove(account);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
