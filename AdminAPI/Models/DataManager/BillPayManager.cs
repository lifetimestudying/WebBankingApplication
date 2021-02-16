using System.Collections.Generic;
using System.Linq;
using AdminAPI.Models.Repository;
using AdminAPI.Data;

namespace AdminAPI.Models.DataManager
{
    public class BillPayManager : IDataRepository<BillPay, int>
    {
        private readonly BankContext _context;

        public BillPayManager(BankContext context)
        {
            _context = context;
        }

        public IEnumerable<BillPay> GetAll()
        {
            return _context.BillPay.ToList();
        }

        public BillPay Get(int id)
        {
            return _context.BillPay.Find(id);
        }

        public int Update(int id, BillPay billPay)
        {
            _context.Update(billPay);
            _context.SaveChanges();

            return id;
        }
    }
}
