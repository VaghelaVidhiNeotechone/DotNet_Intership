using System;
using System.ComponentModel.DataAnnotations;

namespace BankManagement.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountHolder { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountType { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Balance { get; set; }
    }
}
