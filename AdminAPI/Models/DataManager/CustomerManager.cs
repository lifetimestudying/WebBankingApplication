using System.Collections.Generic;
using System.Linq;
using AdminAPI.Models.Repository;
using AdminAPI.Data;

namespace AdminAPI.Models.DataManager
{
    public class CustomerManager : IDataRepository<Customer, int>
    {
        private readonly BankContext _context;

        public CustomerManager(BankContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customer.ToList();
        }

        public Customer Get(int id)
        {
            return _context.Customer.Find(id);
        }

        public int Update(int id, Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();

            return id;
        }
        
    }
}