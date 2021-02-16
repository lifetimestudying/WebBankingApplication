using System.Collections.Generic;
using System.Linq;
using AdminAPI.Models.Repository;
using AdminAPI.Data;

namespace AdminAPI.Models.DataManager
{
    public class AccountManager : IDataRepository<Account, int>
    {
        private readonly BankContext _context;

        public AccountManager(BankContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Account.ToList();
        }

        public Account Get(int id)
        {
            return _context.Account.Find(id);
        }

        public int Update(int id, Account account)
        {
            _context.Update(account);
            _context.SaveChanges();

            return id;
        }

    }
}
