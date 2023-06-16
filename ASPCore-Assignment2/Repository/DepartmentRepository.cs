using ASPCore_Assignment2.Data;
using ASPCore_Assignment2.Models;
using ASPCore_Assignment2.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ASPCore_Assignment2.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public DepartmentRepository(EmplyeeManagementContext context)
        {
            this.context = context;
        }

        public EmplyeeManagementContext context { get; }

        public async Task<Department> AddDepartrmentAsync(Department dept)
        {
        var depname=  await context.Departments.FirstOrDefaultAsync(x=>x.Name.ToLower()==dept.Name.ToLower());
            if (depname==null)
            {
                
                await context.Departments.AddAsync(dept);
                await context.SaveChangesAsync();
                return dept;
            }
            return null;
        }

        public async Task<Department?> DeleteDepartmentAsync(Guid id)
        {
            var dept=await context.Departments.FindAsync(id);
            if (dept == null) {
                return null;
            }
            context.Departments.Remove(dept);
            await context.SaveChangesAsync();
            return dept;
        }

        public async Task<List<Department>> GetDepartmentAsync()
        {
            return await context.Departments.ToListAsync();
        }

        public async Task<Department?> GetDepartmentbyId(Guid id)
        {
            return await context.Departments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Department> UpdateDepartmentAsync(Guid id, UpdateDepartmentDto department)
        {
            var dept = await context.Departments.FirstOrDefaultAsync(x=>x.Id==id);
            if (dept == null)
            {
                return null;
            }
            dept.Name = department.Name;
            await context.SaveChangesAsync();
            return dept;
        }
    }
}
