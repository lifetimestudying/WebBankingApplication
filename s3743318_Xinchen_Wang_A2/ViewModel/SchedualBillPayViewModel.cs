using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBankingApp.Models;

namespace WebBankingApp.ViewModel
{
    public class SchedualBillPayViewModel
    {
        public IEnumerable<Payee> Payees { get; set; }
        public Customer Customer { get; set; }
    }
}
