using System.Collections.Generic;
using AdminWebApp.Models;

namespace AdminWebApp.ViewModels
{
    public class AllTransactionsViewModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }
        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }
    }
}
