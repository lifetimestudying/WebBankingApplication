using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebBankingApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace WebBankingApp.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string LoginID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
