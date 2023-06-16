using ASPCore_Assignment2.Data;
using ASPCore_Assignment2.Models;
using ASPCore_Assignment2.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ASPCore_Assignment2.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmplyeeManagementContext context;
        public EmployeeRepository(EmplyeeManagementContext context)
        {
            this.context = context;
        }

       

        public async Task<Employee> AddEmployeeAsync(Employee emp)
        {
            await context.Employees.AddAsync(emp);
            await context.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee?> DeleteEmployeeAsync(Guid id)
        {
            var emp = await context.Employees.FindAsync(id);
            if (emp == null)
            {
                return null;
            }
            context.Employees.Remove(emp);
            await context.SaveChangesAsync();
            return emp;
        }
        

        public async Task<Employee?> GetEmployeebyId(Guid id)
        {
            return await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Employee>> GetEmpolyeeAsync()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(Guid id, Employee employee )
        {
            var emp = await context.Employees.FindAsync(id);
            if (emp== null)
            {
                return null;
            }
            emp.Age = employee.Age;
            emp.Salary = employee.Salary;
            emp.Name = employee.Name;
            emp.DepartmentId = employee.DepartmentId;

            await context.SaveChangesAsync();
            return emp;
        }

    }
}
