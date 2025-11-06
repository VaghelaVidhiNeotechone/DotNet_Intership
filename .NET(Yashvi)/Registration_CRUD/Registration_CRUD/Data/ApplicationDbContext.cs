using Microsoft.EntityFrameworkCore;
using Registration_CRUD.Models;
using RegistrationFormMVC.Models;  

namespace Registration_CRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserRegistration> UserRegistrations { get; set; }
    }
}
