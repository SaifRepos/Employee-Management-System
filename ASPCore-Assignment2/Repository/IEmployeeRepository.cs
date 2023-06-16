using ASPCore_Assignment2.Models.DTO;
using ASPCore_Assignment2.Models;

namespace ASPCore_Assignment2.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmpolyeeAsync();

        Task<Employee?> GetEmployeebyId(Guid id);

        Task<Employee> AddEmployeeAsync(Employee emp);

        Task<Employee> UpdateEmployeeAsync(Guid id, Employee employee);

        Task<Employee?> DeleteEmployeeAsync(Guid id);
    }
}