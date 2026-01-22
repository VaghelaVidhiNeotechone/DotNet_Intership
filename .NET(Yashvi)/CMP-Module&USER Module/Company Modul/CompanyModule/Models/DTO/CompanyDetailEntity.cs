using CompanyModule.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.DTO
{
    public class CompanyDetailEntity : DTOBaseModel
    {
        [Key]
        public Guid companyid { get; set; }
        public string companyname { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public Guid countryid { get; set; }
        public string timezone { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string phonenumber { get; set; } = string.Empty;
        public string workrequesturl { get; set; } = string.Empty;
        public Guid currencyid { get; set; }
        public int taxregistrationnumber { get; set; }
        public string language { get; set; } = string.Empty;
        public int? pobox { get; set; }
        public Status status { get; set; }
        public bool billable { get; set; }
        public bool settings { get; set; }
        public bool allowworkrequest { get; set; }
        public int thresholdvalue { get; set; }
        public int? vat { get; set; }
        public string purchaserequestemail { get; set; } = string.Empty;

        // Navigation properties
        public virtual Country? Country { get; set; }
        public virtual Currency? Currency { get; set; }
        public virtual ICollection<CompanyAttachment> CompanyAttachments { get; set; } = new List<CompanyAttachment>();
        public virtual ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}