using Employe_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Employe_Management_System.Data
{
    public class EmployeeContext : DbContext

    {
        public EmployeeContext()
        {

        }
        public EmployeeContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }

    }
}
