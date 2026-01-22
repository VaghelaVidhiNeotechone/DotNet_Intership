using CompanyModule.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.DTO
{
    public class Country : DTOBaseModel
    {
        [Key]
        public Guid countryid { get; set; }
        public string countrycode { get; set; } = string.Empty;
        public string countryname { get; set; } = string.Empty;
        public Status status { get; set; }

        // Navigation properties
        public virtual ICollection<CompanyDetailEntity> CompanyDetails { get; set; } = new List<CompanyDetailEntity>();
    }
}