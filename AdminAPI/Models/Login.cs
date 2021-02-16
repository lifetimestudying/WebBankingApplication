using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminAPI.Models
{
    public class Login
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string LoginID { get; set; }

        [Required]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [StringLength(64)]
        public string PasswordHash { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy hh:mm:s tt}", ApplyFormatInEditMode = true)]
        public DateTime ModifyDate { get; set; }

    }
}
