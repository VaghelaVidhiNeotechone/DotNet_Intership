using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.POCO.Request.Country
{
    public class CountryRequest
    {
        [Required(ErrorMessage = "Please enter country code")]
        [StringLength(10)]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "Please enter country name")]
        [StringLength(100)]
        public string CountryName { get; set; }
    }
}
