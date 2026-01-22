using CompanyModule.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.DTO
{
    public class Currency : DTOBaseModel
    {
        [Key]
        public Guid currencyid { get; set; }
        public string currencyname { get; set; } = string.Empty;
        public Status status { get; set; }

        // Navigation properties
        public virtual ICollection<CompanyDetailEntity> CompanyDetails { get; set; } = new List<CompanyDetailEntity>();
    }
}