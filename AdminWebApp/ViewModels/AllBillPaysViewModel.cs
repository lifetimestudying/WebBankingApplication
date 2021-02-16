using System.Collections.Generic;
using AdminWebApp.Models;

namespace AdminWebApp.ViewModels
{
    public class AllBillPaysViewModel
    {
        public IEnumerable<BillPay> BillPays { get; set; }
        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }
    }
}
