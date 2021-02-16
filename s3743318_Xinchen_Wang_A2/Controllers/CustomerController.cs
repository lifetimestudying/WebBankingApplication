using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBankingApp.Data;
using Microsoft.AspNetCore.Http;
using WebBankingApp.Models;
using WebBankingApp.Utilities;
using WebBankingApp.ViewModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebBankingApp.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly BankContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        // ReSharper disable once PossibleInvalidOperationException
        //private int CustomerID => HttpContext.Session.GetInt32(nameof(Customer.CustomerID)).Value;
        
        public CustomerController(UserManager<ApplicationUser> userManager, BankContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var customerID = user.CustomerID;

            // Lazy loading.
            var customer = await _context.Customer.FindAsync(customerID);

            return View(customer);
        }

        // get transactions from account selected
        private static StatementViewModel GetTransactions(Customer customer, int? id, int currentPage)
        {
            StatementViewModel statementViewModel = new StatementViewModel();

            // transactions displayed per page
            const int transactionPerPage = 4;

            // check if account been selected
            if (id != null)
            {
                // get selected account
                var account = customer.Account.FirstOrDefault(x => x.AccountNumber == id);
                
                // get transactions from selected account
                var transactions = account.Transactions;

                // calculate how many pages based on total transactions
                double pageCount = (double)(transactions.Count / Convert.ToDecimal(transactionPerPage));

                statementViewModel = new StatementViewModel
                {
                    Transactions = transactions.OrderByDescending(x => x.TransactionTimeUtc).
                    Skip((currentPage - 1) * transactionPerPage).
                    Take(transactionPerPage).ToList(),
                    Accounts = customer.Account,
                    PageCount = (int)Math.Ceiling(pageCount),
                    CurrentPageIndex = currentPage
                };

                return statementViewModel;
            }

            statementViewModel.Accounts = customer.Account;

            return statementViewModel;

        }

        public async Task<IActionResult> Statement(int? id, int page = 1)
        {
            var user = await _userManager.GetUserAsync(User);
            var customerID = user.CustomerID;

            var customer = await _context.Customer.FindAsync(customerID);

            return View(GetTransactions(customer, id, page)); 
        }

        public async Task<IActionResult> ATM()
        {
            var user = await _userManager.GetUserAsync(User);
            var customerID = user.CustomerID;
            var customer = await _context.Customer.FindAsync(customerID);
            var accounts = _context.Account;

            ATMViewModel atmViewModel = new ATMViewModel
            {
                Accounts = customer.Account,
                AllAccounts = accounts
            };

            return View(atmViewModel);
        } 
        
        [HttpPost]
        public async Task<IActionResult> ATM(TransactionType? transactionType, int? fromAccountNumber, int? toAccountNumber, decimal amount, string comment)
        {
            var user = await _userManager.GetUserAsync(User);
            var customerID = user.CustomerID;

            var customer = await _context.Customer.FindAsync(customerID);

            var accountFrom = await _context.Account.FindAsync(fromAccountNumber);
            var accountTo = await _context.Account.FindAsync(toAccountNumber);

            if (amount <= 0)
                ModelState.AddModelError(nameof(amount), "Amount must be positive.");
            
            if (amount.HasMoreThanTwoDecimalPlaces())
                ModelState.AddModelError(nameof(amount), "Amount cannot have more than 2 decimal places.");
            
            if (!ModelState.IsValid)
            {
                ViewBag.Amount = amount;
                ViewBag.FromAccountNumber = fromAccountNumber;
                ViewBag.TransactionType = transactionType;
                return View(customer);
            }

            if (transactionType == null)
            {
                ModelState.AddModelError(nameof(transactionType), "Transaction Type is required.");
            }

            if (fromAccountNumber == null)
            {
                ModelState.AddModelError(nameof(fromAccountNumber), "Account is required.");
            }

            if (transactionType == TransactionType.Deposit)
            {
                // call account behaviour
                accountFrom.Deposit(amount);
            } 
            else if (transactionType == TransactionType.Withdraw)
            {
                if(accountFrom.EnoughBalance(amount))
                {
                    // call account behaviour
                    accountFrom.Withdraw(amount);
                    
                    // charge withdraw fee if more than 4 transactions
                    if (customer.GetTotalTransactions() > 4)
                    {
                        accountFrom.ChargeWithdrawServiceFee();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Not enough balance");
                }
                 
            }
            else if (transactionType == TransactionType.Transfer)
            {
                if (accountFrom.EnoughBalance(amount))
                {
                    accountFrom.Tranfer(accountTo, amount, comment);

                    // charge transfer fee
                    if (customer.GetTotalTransactions() > 4)
                    {
                        accountFrom.ChargeTransferServiceFee();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Not enough balance");
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SchedualBillPay()
        {
            var user = await _userManager.GetUserAsync(User);
            var customerID = user.CustomerID;
            var customer = await _context.Customer.FindAsync(customerID);
            var payee = _context.Payee;

            SchedualBillPayViewModel schedualBillPayViewModel = new SchedualBillPayViewModel()
            {
                Customer = customer,
                Payees = payee
            };

            return View(schedualBillPayViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SchedualBillPay(int accountNumber, int payeeID, decimal amount, DateTime schedualDate, DateTime schedualTime, Period period)
        {
            var user = await _userManager.GetUserAsync(User);
            var customerID = user.CustomerID;
            var customer = await _context.Customer.FindAsync(customerID);
            var account = customer.Account.FirstOrDefault(x => x.AccountNumber == accountNumber);
            var schedualDateTimeString = schedualDate.ToString("dd/MM/yyyy ") + schedualTime.ToString("hh:mm:ss tt");
            var schedualDateTime = DateTime.ParseExact(schedualDateTimeString, "dd/MM/yyyy hh:mm:ss tt", null).ToUniversalTime();

            if (amount <= 0)
                ModelState.AddModelError(nameof(amount), "Amount must be positive.");

            if (amount.HasMoreThanTwoDecimalPlaces())
                ModelState.AddModelError(nameof(amount), "Amount cannot have more than 2 decimal places.");

            if (!ModelState.IsValid)
            {
                ViewBag.Amount = amount;
                return View();
            }

            account.AddBillPay(payeeID, amount, schedualDateTime, period);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ManageBillPay()
        {
            var user = await _userManager.GetUserAsync(User);
            var customerID = user.CustomerID;
            var customer = await _context.Customer.FindAsync(customerID);
            var accounts = customer.Account;

            List<BillPay> billPays = new List<BillPay>();

            foreach (var account in accounts)
            {
                foreach (var bill in account.BillPays)
                {
                    billPays.Add(bill);
                }
            }

            ManageSchedualBillPayViewModel manageSchedualBillPayViewModel
                = new ManageSchedualBillPayViewModel { BillPays = billPays };

            return View(manageSchedualBillPayViewModel);
        }

        public async Task<IActionResult> EditBillPay(int? id)
        {
            var billpay = await _context.BillPay.FindAsync(id);

            return PartialView("_EditBillPayPartial", billpay);
        }

        [HttpPost]
        public async Task<IActionResult> EditBillPay(int id, decimal amount, DateTime schedualDate, DateTime schedualTime, Period period)
        {
            var billpay = await _context.BillPay.FindAsync(id);

            var schedualDateTimeString = schedualDate.ToString("dd/MM/yyyy ") + schedualTime.ToString("hh:mm:ss tt");
            var schedualDateTime = DateTime.ParseExact(schedualDateTimeString, "dd/MM/yyyy hh:mm:ss tt", null).ToUniversalTime();

            if (amount <= 0)
                ModelState.AddModelError(nameof(amount), "Amount must be positive.");

            if (amount.HasMoreThanTwoDecimalPlaces())
                ModelState.AddModelError(nameof(amount), "Amount cannot have more than 2 decimal places.");

            if (!ModelState.IsValid)
            {
                ViewBag.Amount = amount;
                return View();
            }

            billpay.Amount = amount;
            billpay.SchedualDate = schedualDateTime;
            billpay.Period = period;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageBillPay));
        }


    }
}
