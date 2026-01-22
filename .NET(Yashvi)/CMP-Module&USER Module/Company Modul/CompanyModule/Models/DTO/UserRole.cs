using CompanyModule.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.DTO
{
    public class UserRole : DTOBaseModel
    {
        [Key]
        public Guid roleid { get; set; }
        public string rolename { get; set; } = string.Empty;
        public Guid companyid { get; set; }
        public Status statusid { get; set; }
        public Guid createdby { get; set; }
        public DateTime createdon { get; set; } = DateTime.UtcNow;
        public Guid? updatedby { get; set; }
        public DateTime? updatedon { get; set; }

        // Navigation properties
        public virtual ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}