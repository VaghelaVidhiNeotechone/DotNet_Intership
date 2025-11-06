using Microsoft.EntityFrameworkCore;

namespace AspCoreCRUDCodeFirst.Models
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options) 
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
