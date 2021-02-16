using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminWebApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using AdminWebApp.ViewModels;
using AdminWebApp.Utilities;

namespace AdminWebApp.Controllers
{
    [AuthorizeAdmin]
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient Client => _clientFactory.CreateClient("api");

        public AdminController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        
        public async Task<IActionResult> Index()
        {
            var response = await Client.GetAsync("api/AdminApi/customers");

            if(!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            // Storing the response details received from web api.
            var result = await response.Content.ReadAsStringAsync();

            // Deserializing the response received from web api and storing into a list.
            var customer = JsonConvert.DeserializeObject<List<Customer>>(result);

            return View(customer);
        }

        // get accounts of that customer
        // GET: Admin/CustomerAccounts/1        
        public async Task<IActionResult> CustomerAccounts(int? id)
        {
            var response = await Client.GetAsync($"api/AdminApi/customer/{id}/accounts");
            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            // Storing the response details received from web api.
            var result = await response.Content.ReadAsStringAsync();

            // Deserializing the response received from web api and storing into a list.
            var accounts = JsonConvert.DeserializeObject<List<Account>>(result);

            return View(accounts);
        }

        // GET: Admin/CustomerTransactions/AccountTransactions/1?page=1&transactionPerPage=5
        public async Task<IActionResult> AccountTransactions(int id, int page = 1, int transactionPerPage = 5)
        {
            var transactions = await GetAccountTransactions(id, page, transactionPerPage);

            return View(transactions);
        }

        // GET: Admin/CustomerBillPays/1
        public async Task<IActionResult> AccountBillPays(int id, int page = 1, int transactionPerPage = 5)
        {
            var billpays = await GetAccountBillPays(id, page, transactionPerPage);

            return View(billpays);
        }

        // lock account
        public async Task<IActionResult> LockAccount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await Client.GetAsync($"api/AdminApi/accounts/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            // Storing the response details received from web api.
            var account = response.Content;

            await Client.PutAsync($"api/AdminApi/lockAccount", account);

            return RedirectToAction("Index");
        }

        // unlock account
        public async Task<IActionResult> UnlockAccount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await Client.GetAsync($"api/AdminApi/accounts/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            // Storing the response details received from web api.
            var account = response.Content;

            await Client.PutAsync("api/AdminApi/unlockAccount", account);

            return RedirectToAction("Index");
        }

        // lock bill pay
        public async Task<IActionResult> LockBillPay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await Client.GetAsync($"api/AdminApi/billPays/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            // Storing the response details received from web api.
            var billPay = response.Content;

            await Client.PutAsync("api/AdminApi/lockBillPay", billPay);
      
            return RedirectToAction("Index");
        }

        // unlock bill pay
        public async Task<IActionResult> UnlockBillPay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await Client.GetAsync($"api/AdminApi/billPays/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            // Storing the response details received from web api.
            var billPay = response.Content;

            await Client.PutAsync($"api/AdminApi/unlockBillPay", billPay);

            return RedirectToAction("Index");
        }

        // lock customer
        public async Task<IActionResult> LockCustomer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await Client.GetAsync($"api/AdminApi/customers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            // Storing the response details received from web api.
            var customer = response.Content;

            await Client.PutAsync($"api/AdminApi/lockCustomer", customer);
            _ = AutoUnlockCustomer(customer);

            return RedirectToAction("Index");
        }

        // auto unlock customer after 1 min according to business rule
        private async Task AutoUnlockCustomer(HttpContent customer)
        {
            await Task.Delay(60000);
            await Client.PutAsync("api/AdminApi/unlockCustomer", customer);
        }

        // unlock customer
        public async Task<IActionResult> UnlockCustomer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await Client.GetAsync($"api/AdminApi/customers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            // Storing the response details received from web api.
            var customer = response.Content;

            await Client.PutAsync($"api/AdminApi/unlockCustomer", customer);

            return RedirectToAction("Index");
        }

        // GET: Admin/AllAccounts
        public async Task<IActionResult> AllAccounts(int page = 1, int itemPerPage = 10)
        {
            var accounts = await GetAllAccounts(page, itemPerPage);
            return View(accounts);
        }

        // GET: Admin/AllTransactions
        public async Task<IActionResult> AllTransactions(int page = 1, int itemPerPage = 10)
        {
            var transactions = await GetAllTransactions(page, itemPerPage);
            return View(transactions);
        }

        // GET: Admin/AllBillPays
        public async Task<IActionResult> AllBillPays(int page = 1, int itemPerPage = 10)
        {
            var billPays = await GetAllBillPays(page, itemPerPage);
            return View(billPays);
        }

        // get transactions of that account
        private async Task<AllTransactionsViewModel> GetAccountTransactions(int id, int currentPage, int itemPerPage)
        {
            var response = await Client.GetAsync($"api/AdminApi/account/{id}/transactions");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            // Storing the response details received from web api.
            var result = await response.Content.ReadAsStringAsync();

            // Deserializing the response received from web api and storing into a list.
            var transactions = JsonConvert.DeserializeObject<List<Transaction>>(result);

            // calculate how many pages based on total transactions
            double pageCount = (double)(transactions.Count / Convert.ToDecimal(itemPerPage));

            AllTransactionsViewModel allTransactionsViewModel = new AllTransactionsViewModel
            {
                Transactions = transactions.OrderByDescending(x => x.TransactionTimeUtc).
                Skip((currentPage - 1) * itemPerPage).
                Take(itemPerPage).ToList(),
                PageCount = (int)Math.Ceiling(pageCount),
                CurrentPageIndex = currentPage
            };

            return allTransactionsViewModel;
        }

        // get bill pays of that account
        private async Task<AllBillPaysViewModel> GetAccountBillPays(int id, int currentPage, int itemPerPage)
        {
            var response = await Client.GetAsync($"api/AdminApi/account/{id}/billPays");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            // Storing the response details received from web api.
            var result = await response.Content.ReadAsStringAsync();

            // Deserializing the response received from web api and storing into a list.
            var billPays = JsonConvert.DeserializeObject<List<BillPay>>(result);

            // calculate how many pages based on total transactions
            double pageCount = (double)(billPays.Count / Convert.ToDecimal(itemPerPage));

            AllBillPaysViewModel allBillPaysViewModel = new AllBillPaysViewModel
            {
                BillPays = billPays.OrderByDescending(x => x.ModifyDate).
                Skip((currentPage - 1) * itemPerPage).
                Take(itemPerPage).ToList(),
                PageCount = (int)Math.Ceiling(pageCount),
                CurrentPageIndex = currentPage
            };

            return allBillPaysViewModel;
        }

        // get all transactions
        private async Task<AllTransactionsViewModel> GetAllTransactions(int currentPage, int itemPerPage)
        {
            var response = await Client.GetAsync("api/AdminApi/transactions");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            // Storing the response details received from web api.
            var result = await response.Content.ReadAsStringAsync();

            // Deserializing the response received from web api and storing into a list.
            var transactions = JsonConvert.DeserializeObject<List<Transaction>>(result);

            // calculate how many pages based on total transactions
            double pageCount = (double)(transactions.Count / Convert.ToDecimal(itemPerPage));

            AllTransactionsViewModel allTransactionsViewModel = new AllTransactionsViewModel
            {
                Transactions = transactions.OrderByDescending(x => x.TransactionTimeUtc).
                Skip((currentPage - 1) * itemPerPage).
                Take(itemPerPage).ToList(),
                PageCount = (int)Math.Ceiling(pageCount),
                CurrentPageIndex = currentPage
            };

            return allTransactionsViewModel;
        }

        // get all bill pays
        private async Task<AllBillPaysViewModel> GetAllBillPays(int currentPage, int itemPerPage)
        {

            var response = await Client.GetAsync("api/AdminApi/billPays");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            // Storing the response details received from web api.
            var result = await response.Content.ReadAsStringAsync();

            // Deserializing the response received from web api and storing into a list.
            var billPays = JsonConvert.DeserializeObject<List<BillPay>>(result);

            // calculate how many pages based on total transactions
            double pageCount = (double)(billPays.Count / Convert.ToDecimal(itemPerPage));

            AllBillPaysViewModel allBillPaysViewModel = new AllBillPaysViewModel
            {
                BillPays = billPays.OrderByDescending(x => x.ModifyDate).
                Skip((currentPage - 1) * itemPerPage).
                Take(itemPerPage).ToList(),
                PageCount = (int)Math.Ceiling(pageCount),
                CurrentPageIndex = currentPage
            };

            return allBillPaysViewModel;
        }


        // get all accounts
        private async Task<AllAccountsViewModel> GetAllAccounts(int currentPage, int itemPerPage)
        {
            var response = await Client.GetAsync("api/AdminApi/accounts");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            // Storing the response details received from web api.
            var result = await response.Content.ReadAsStringAsync();

            // Deserializing the response received from web api and storing into a list.
            var accounts = JsonConvert.DeserializeObject<List<Account>>(result);

            // calculate how many pages based on total transactions
            double pageCount = (double)(accounts.Count / Convert.ToDecimal(itemPerPage));

            AllAccountsViewModel allAccountsViewModel = new AllAccountsViewModel
            {
                Accounts = accounts.OrderByDescending(x => x.ModifyDate).
                Skip((currentPage - 1) * itemPerPage).
                Take(itemPerPage).ToList(),
                PageCount = (int)Math.Ceiling(pageCount),
                CurrentPageIndex = currentPage
            };

            return allAccountsViewModel;
        }
    }
}
