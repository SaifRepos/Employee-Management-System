using AutoMapper;
using Employe_Management_System.Data;
using Employe_Management_System.Dto;
using Employe_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employe_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly EmployeeContext _context;
        private readonly IMapper _mapper;

        public DepartmentController(EmployeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartment()
        {
            var departments = await _context.departments.ToListAsync();
            return Ok(departments);

        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentDto dto)
        {
            if (String.IsNullOrEmpty(dto.Name))
            {
                return BadRequest("Department Name Should Not Be Empty");

            }
            var newDepartment = _mapper.Map<Department>(dto);
            if (DepartmentExists(newDepartment.Name.ToLower()))
            {
                return Conflict("Department Exist");
            }
            await _context.departments.AddAsync(newDepartment);
            await _context.SaveChangesAsync();
            return Created($"/{newDepartment.Department_Id}", newDepartment);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditDepartment(int id, DepartmentDto dto)
        {
            Department? departments = await _context.departments.FindAsync(id);
            if (departments == null)
            {
                return BadRequest("Department Does Not Exist");
            }
            departments.Name = dto.Name;
            
            _context.Update(departments);
            await _context.SaveChangesAsync();
            return Ok(departments);
        }
            [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (_context.departments == null)
            {
                return NotFound();
            }
            var dep = await _context.departments.FindAsync(id);
            if (dep == null)
            {
                return NotFound("Department Not Found");
            }

            _context.departments.Remove(dep);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool DepartmentExists(String str)
        {
            return (_context.departments?.Any(e => e.Name.ToLower() == str)).GetValueOrDefault();
        }

    }
}
