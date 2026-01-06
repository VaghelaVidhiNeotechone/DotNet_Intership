using Company_module.Models.Enums;
using System.ComponentModel.DataAnnotations;


namespace Company_module.Models.POCO.Request.CompanyDetail
{
    public class CompanyDetailRequest
    {
        public Guid companyid { get; set; }


        [Required(ErrorMessage = "Company name is required")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Company name must be between 3 and 100 characters.")]
        public string companyname { get; set; }


        [Required(ErrorMessage = "Address is required")]
        public string address { get; set; }


        [Required(ErrorMessage = "CountryName is required")]
        public string CountryName { get; set; }
        public string timezone { get; set; }


        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(15, ErrorMessage = "Phone number should be max 15 digits.")]
        public string phonenumber { get; set; }
        public string workrequesturl { get; set; }


        [Required(ErrorMessage = "CurrencyName is required")]
        public string CurrencyName { get; set; }
        public int taxregistrationnumber { get; set; }
        public string language { get; set; }
        public int? pobox { get; set; }


        [Required(ErrorMessage = "Status is required")]
        public Status status { get; set; }
        public bool billable { get; set; }
        public bool settings { get; set; }
        public bool allowworkrequest { get; set; }


        [Range(1, int.MaxValue,
            ErrorMessage = "Threshold value must be greater than 0.")]
        public int thresholdvalue { get; set; }


        [Range(0, 100, ErrorMessage = "VAT must be between 0 and 100.")]
        public int? vat { get; set; }


        [Required(ErrorMessage = "Purchase request email is required")]
        [EmailAddress(ErrorMessage = "Provide a valid email address")]
        public string purchaserequestemail { get; set; }
        public bool isdeleted { get; set; }
    }
}
