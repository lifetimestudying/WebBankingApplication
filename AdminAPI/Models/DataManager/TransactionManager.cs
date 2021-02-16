using System.Collections.Generic;
using System.Linq;
using AdminAPI.Models.Repository;
using AdminAPI.Data;

namespace AdminAPI.Models.DataManager
{
    public class TransactionManager : IDataRepository<Transaction, int>
    {
        private readonly BankContext _context;

        public TransactionManager(BankContext context)
        {
            _context = context;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _context.Transaction.ToList();
        }

        public Transaction Get(int id)
        {
            return _context.Transaction.Find(id);
        }

        public int Update(int id, Transaction transaction)
        {
            _context.Update(transaction);
            _context.SaveChanges();

            return id;
        }
    }
}
