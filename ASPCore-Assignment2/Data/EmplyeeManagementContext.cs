using ASPCore_Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPCore_Assignment2.Data
{
    public class EmplyeeManagementContext:DbContext
    {
        public EmplyeeManagementContext(DbContextOptions options) : base(options )
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        
    }
}
