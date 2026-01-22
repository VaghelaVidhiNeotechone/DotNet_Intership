using System.ComponentModel.DataAnnotations;

namespace CompanyModule.Models.DTO
{
    public class ApplicationUser : DTOBaseModel
    {
        [Key]
        public Guid userid { get; set; }
        public string fullname { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public Guid? companyid { get; set; }
        public Guid? roleid { get; set; }
        public int statusid { get; set; }
        public DateTime? dateofbirth { get; set; }
        public DateTime createdon { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public virtual UserRole? UserRole { get; set; }
        public virtual CompanyDetailEntity? Company { get; set; }
        public virtual ICollection<UserFile> UserFiles { get; set; } = new List<UserFile>();
    }
}