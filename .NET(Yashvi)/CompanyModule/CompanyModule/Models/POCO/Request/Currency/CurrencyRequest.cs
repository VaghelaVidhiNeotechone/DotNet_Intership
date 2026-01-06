using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.POCO.Request.Currency
{
    public class CurrencyRequest
    {
        [Required(ErrorMessage = "Please enter currency name")]
        public string CurrencyName { get; set; } = string.Empty;
    }
}
