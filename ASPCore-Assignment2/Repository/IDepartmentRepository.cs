using ASPCore_Assignment2.Models;
using ASPCore_Assignment2.Models.DTO;

namespace ASPCore_Assignment2.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartmentAsync();

        Task<Department?> GetDepartmentbyId(Guid id);

        Task<Department> AddDepartrmentAsync(Department dept);

        Task<Department> UpdateDepartmentAsync(Guid id, UpdateDepartmentDto department);

        Task<Department?> DeleteDepartmentAsync(Guid id);
    }
}
