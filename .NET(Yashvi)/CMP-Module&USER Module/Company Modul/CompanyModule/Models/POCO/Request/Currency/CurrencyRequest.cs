using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.POCO.Request.Currency
{
    public class CurrencyRequest
    {
        [Required(ErrorMessage = "Please enter currency name")]
        [StringLength(100)]
        public string CurrencyName { get; set; }
    }
}
