using AutoMapper;
using Employe_Management_System.Data;
using Employe_Management_System.Dto;
using Employe_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Employe_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;
        private readonly IMapper _mapper;
        public EmployeeController(EmployeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Getemployees()
        {
            if (_context.employees == null)
            {
                return NotFound();
            }
            return await _context.employees.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Getemployees(int id)
        {
            if (_context.employees == null)
            {
                return NotFound();
            }
            var emp = await _context.employees.FindAsync(id);

            if (emp == null)
            {
                return NotFound("Employee Does not exist");
            }

            return emp;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(EmployeeDto dto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var e = await _context.departments.FindAsync(dto.Department_Id);
            if (e == null)
            {
                return BadRequest("Please Enter valid Department ID");
            }

            var newEmployee = _mapper.Map<Employee>(dto);
            await _context.employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return Created($"/{newEmployee.Id}", newEmployee);


        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> RemoveEmployeeAsync(int id)
        {
            if (_context.employees == null)
            {
                return NotFound();
            }
            var emp = await _context.employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound("Employee Not Found");
            }

            _context.employees.Remove(emp);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployee(int id, EmployeeDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Employee? emp = await _context.employees.FindAsync(id);
            if (emp == null)
            {
                return BadRequest();
            }
            var e = await _context.departments.FindAsync(id);
            if (e == null)
            {
                return BadRequest("Please Enter valid Department ID");
            }
            var updatedemployee = _mapper.Map<Employee>(dto);
            _context.Update(updatedemployee);
            await _context.SaveChangesAsync();
            return Ok(updatedemployee);




        }
    }
}
