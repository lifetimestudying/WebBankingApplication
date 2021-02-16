using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AdminAPI.Models;
using AdminAPI.Models.DataManager;
using System;

namespace AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private readonly CustomerManager _customerRepo;
        private readonly AccountManager _accountRepo;
        private readonly TransactionManager _transactionRepo;
        private readonly BillPayManager _billPayRepo;
 

        public AdminApiController(CustomerManager customerRepo, AccountManager accountRepo, 
            TransactionManager transactionRepo, BillPayManager billPayRepo)
        {
            _customerRepo = customerRepo;
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
            _billPayRepo = billPayRepo;
        }

        // GET: api/AdminApi/customers
        [HttpGet("customers")]
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepo.GetAll();
        }

        // GET: api/AdminApi/customers/1
        [HttpGet("customers/{id}")]
        public Customer GetCustomer(int id)
        {
            return _customerRepo.Get(id);
        }

        // GET: api/AdminApi/accounts
        [HttpGet("accounts")]
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accountRepo.GetAll();
        }

        // GET: api/AdminApi/accounts/1
        [HttpGet("accounts/{id}")]
        public Account GetAccount(int id)
        {
            return _accountRepo.Get(id);
        }

        // PUT: api/AdminApi/lockCustomer
        [HttpPut("lockCustomer")]
        public void LockCustomer([FromBody] Customer customer)
        {
            customer.CustomerStatus = Status.Locked;
            _customerRepo.Update(customer.CustomerID, customer);
        }

        // PUT: api/AdminApi/unlockCustomer
        [HttpPut("unlockCustomer")]
        public void UnlockCustomer([FromBody] Customer customer)
        {
            customer.CustomerStatus = Status.Activate;
            _customerRepo.Update(customer.CustomerID, customer);
        }

        // PUT api/AdminApi/lockAccount
        [HttpPut("lockAccount")]
        public void LockAccount([FromBody] Account account)
        {
            account.AccountStatus = Status.Locked;
            _accountRepo.Update(account.AccountNumber, account);
        }

        // PUT api/AdminApi/unlockAccount
        [HttpPut("unlockAccount")]
        public void UnlockAccount([FromBody] Account account)
        {
            account.AccountStatus = Status.Activate;
            _accountRepo.Update(account.AccountNumber, account);
        }

        // GET: api/AdminAPI/transactions
        [HttpGet("transactions")]
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _transactionRepo.GetAll();
        }

        // GET: api/AdminApi/transactions/1
        [HttpGet("transactions/{id}")]
        public Transaction GetTransaction(int id)
        {
            return _transactionRepo.Get(id);
        }

        // GET: api/AdminApi/billPays
        [HttpGet("billPays")]
        public IEnumerable<BillPay> GetAllBillPays()
        {
            return _billPayRepo.GetAll();
        }

        // GET: api/AdminApi/billPays/1
        [HttpGet("billPays/{id}")]
        public BillPay GetBillPay(int id)
        {
            return _billPayRepo.Get(id);
        }

        // PUT: api/AdminApi/lockBillPay
        [HttpPut("lockBillPay")]
        public void LockBillPay([FromBody] BillPay billPay)
        {
            billPay.BillPayStatus = Status.Locked;
            _billPayRepo.Update(billPay.BillPayID, billPay);
        }

        // PUT: api/AdminApi/unlockBillPay
        [HttpPut("unlockBillPay")]
        public void UnlockBillPay([FromBody] BillPay billPay)
        {
            billPay.BillPayStatus = Status.Activate;
            _billPayRepo.Update(billPay.BillPayID, billPay);
        }

        // GET: api/AdminApi/customers/1/accounts
        [HttpGet("customer/{id}/accounts")]
        public IEnumerable<Account> GetAllCustomerAccounts(int id)
        {
            var accountList = new List<Account>();

            var accounts = GetAllAccounts();

            foreach (var account in accounts)
            {
                if (account.CustomerID == id)
                {
                    accountList.Add(account);
                }
            }

            return accountList;
        }

        // GET: api/AdminApi/account/1/transactions
        [HttpGet("account/{id}/transactions")]
        public IEnumerable<Transaction> GetAccountsTransactions(int id)
        {
            var transactionList = new List<Transaction>();

            var transactions = GetAllTransactions();

            foreach (var transaction in transactions)
            {
                if (transaction.AccountNumber == id)
                {
                    transactionList.Add(transaction);
                }
            }

            return transactionList;
        }

        // GET: api/AdminApi/account/1/billPays
        [HttpGet("account/{id}/billPays")]
        public IEnumerable<BillPay> GetAccountsBillPays(int id)
        {
            var billPayList = new List<BillPay>();

            var billPays = GetAllBillPays();

            foreach (var billPay in billPays)
            {
                if (billPay.AccountNumber == id)
                {
                    billPayList.Add(billPay);
                }
            }

            return billPayList;
        }

    }
}
