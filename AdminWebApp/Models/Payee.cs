using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace AdminWebApp.Models
{
    public class Payee
    {
        public int PayeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string PayeeName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(20)]
        public State? State { get; set; }

        [StringLength(10)]
        public string PostCode { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(+61)(?!$)(?([0-9]{4}))(?!$)(?([0-9]{4}))$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        
        public virtual ICollection<BillPay> BillPay { get; set; }
    }
}
