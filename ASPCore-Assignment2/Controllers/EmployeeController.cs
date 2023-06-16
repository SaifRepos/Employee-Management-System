using ASPCore_Assignment2.CustomeActionFilter;
using ASPCore_Assignment2.Models;
using ASPCore_Assignment2.Models.DTO;
using ASPCore_Assignment2.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCore_Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository emprepository;
        public EmployeeController(IMapper mapper, IEmployeeRepository emprepository)
        {
            this.mapper = mapper;
            this.emprepository = emprepository;
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> GetEmployees(AddEmployeeDto dto)
        {

            var newemployee = mapper.Map<Employee>(dto);
            newemployee = await emprepository.AddEmployeeAsync(newemployee);

            return Ok(mapper.Map<EmployeeDto>(newemployee));
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            var employee = await emprepository.GetEmpolyeeAsync();
            if (employee == null)
            {
                return NotFound();
            }
            var emplist = mapper.Map<List<EmployeeDto>>(employee);
            return Ok(emplist);
        }
        [HttpGet("{id:Guid}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var emp = await emprepository.GetEmployeebyId(id);
            if (emp == null)
            {
                return NotFound("Not Found");
            }
            return Ok(emp);
        }
        [HttpPut("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateEmployee(Guid id,UpdateEmployeeDto dto)
        {
            var emp = mapper.Map<Employee>(dto);
            emp = await emprepository.UpdateEmployeeAsync(id, emp);
            if (emp == null)
            {
                return BadRequest();

            }



            return Ok(mapper.Map<UpdateEmployeeDto>(emp));

        }
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {

            var emp = await emprepository.DeleteEmployeeAsync(id);
            if (emp == null)
            {
                return NotFound("Employee Not Found");
            }

            return CreatedAtAction(nameof(DeleteEmployee), new { id = id }, emp);
        }

    }
}
