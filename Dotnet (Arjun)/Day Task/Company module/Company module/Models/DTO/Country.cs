using Company_module.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Company_module.Models.DTO
{
    public class Country : DTOBaseModel
    {
        [Key]
        public Guid CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public Status Status { get; set; }
        public bool IsDeleted { get; set; }


        public virtual ICollection<CompanyDetailEntity> CompanyDetails { get; set; }
    }
}
