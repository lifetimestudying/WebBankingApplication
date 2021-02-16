using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBankingApp.Models
{ 
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }
        
        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(11)]
        public string TFN { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(20)]
        public State? State { get; set; }

        [StringLength(10)]
        public string PostCode { get; set; }
        
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]  
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[+]*61\s[0-9][0-9][0-9][0-9]\s[0-9][0-9][0-9][0-9]$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        public Status CustomerStatus { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual Login Login { get; set; }
    }
}
