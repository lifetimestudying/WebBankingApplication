using System.Collections.Generic;
using AdminWebApp.Models;

namespace AdminWebApp.ViewModels
{
    public class AllAccountsViewModel
    {
        public IEnumerable<Account> Accounts { get; set; }
        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }
    }
}
