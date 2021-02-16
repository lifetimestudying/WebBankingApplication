using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBankingApp.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }

        [Required]
        [StringLength(1)]
        public TransactionType TransactionType { get; set; }
        
        [Required]
        [ForeignKey("Account")]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }
        
        [ForeignKey("DestAccount")]
        public int? DestAccountNumber { get; set; }
        public virtual Account DestAccount { get; set; }

        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        public decimal? Amount { get; set; }

        [StringLength(255)]
        public string Comment { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Modify Date")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy hh:mm:s tt}", ApplyFormatInEditMode = true)]
        public DateTime? TransactionTimeUtc { get; set; }


    }
}
