using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspCoreCRUDCodeFirst.Models
{
    public class Employee
    {
        [Key]
        [DisplayName("ID")]
        public int Emp_Id { get; set; }

        [Required]
        [MaxLength(200)]
        [DisplayName("Name")]
        public string Emp_Name { get; set; }

        [Required]
        [DisplayName("Age")]
        public int Emp_Age { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string Emp_Gender { get; set; }

        [Required]
        [DisplayName("DOJ")]
        public DateTime DOJ { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public int Salary { get; set; }
    }
}
