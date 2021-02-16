using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBankingApp.Models
{
    public class BillPay
    {
        public int BillPayID { get; set; }

        [Required]
        [ForeignKey("Account")]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }

        [Required]
        public int PayeeID { get; set; }
        public virtual Payee Payee { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Schedual Date")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SchedualDate { get; set; }

        [Required]
        public Period Period { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Modify Date")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy hh:mm:s tt}", ApplyFormatInEditMode = true)]
        public DateTime ModifyDate { get; set; }

        public Status BillPayStatus { get; set; }

    }

}
