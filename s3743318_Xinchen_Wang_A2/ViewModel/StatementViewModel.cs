using System.Collections.Generic;
using WebBankingApp.Models;

namespace WebBankingApp.ViewModel
{
    public class StatementViewModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }
    }
}
