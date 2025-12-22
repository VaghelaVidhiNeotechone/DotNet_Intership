using Company_module.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Company_module.Models.DTO
{
    public class Currency : DTOBaseModel
    {
        [Key]
        public Guid CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public Status Status { get; set; }
        public bool IsDeleted { get; set; }


        public virtual ICollection<CompanyDetailEntity> CompanyDetails { get; set; }
    }
}
