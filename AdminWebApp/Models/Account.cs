using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminWebApp.Models
{
    public class Account
    {
        [Key]
        [Display(Name = "Account Number")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountNumber { get; set; }

        [Required]
        public AccountType AccountType { get; set; }

        [Required]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy hh:mm:s tt}", ApplyFormatInEditMode = true)]
        public DateTime ModifyDate { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public Status AccountStatus { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<BillPay> BillPays { get; set; }

    }

    
}
