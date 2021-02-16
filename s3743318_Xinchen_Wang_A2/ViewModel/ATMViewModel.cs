using System.Collections.Generic;
using WebBankingApp.Models;

namespace WebBankingApp.ViewModel
{
    public class ATMViewModel
    {
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Account> AllAccounts { get; set; }
    }
}
