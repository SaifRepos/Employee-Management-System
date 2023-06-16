using ASPCore_Assignment2.CustomeActionFilter;
using ASPCore_Assignment2.Models;
using ASPCore_Assignment2.Models.DTO;
using ASPCore_Assignment2.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ASPCore_Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDepartmentRepository deptrepo;

        public DepartmentController(IMapper mapper,IDepartmentRepository deptrepo)
        {
            this.mapper = mapper;
            this.deptrepo = deptrepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetDepartment()
        {
           var dept= await deptrepo.GetDepartmentAsync();
            if (dept == null)
            {
                return NotFound();
            }
            var deptlist=mapper.Map<List<DepartmentDto>>(dept);
            return Ok(deptlist);
        }
        [HttpGet("{id:Guid}")]
        
        public async Task<IActionResult> GetById(Guid id)
        {
            var dept=await deptrepo.GetDepartmentbyId(id);
            if (dept == null)
            {
                return NotFound("Not Found");
            }
            return Ok(dept);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddDepartment(UpdateDepartmentDto dto)
        {
            var newdepartment=mapper.Map<Department>(dto);
            var ax= await deptrepo.AddDepartrmentAsync(newdepartment);
            if (ax == null)
            {
                return BadRequest("Department Already Exist");
            }
            return Created($"/{newdepartment.Id}", newdepartment);
        }
    
        [HttpPut("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateDepartment(Guid id,UpdateDepartmentDto dto)
        {
            var dept= mapper.Map<Department>(dto);
           dept= await deptrepo.UpdateDepartmentAsync(id,dto);
            if (dept == null)
            {
                return BadRequest();
                
            }

         

            return Ok(mapper.Map<UpdateDepartmentDto>(dept));

        }
       
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {

            var dept = await deptrepo.DeleteDepartmentAsync(id);
            if (dept == null)
            {
                return NotFound("Department Not Found");
            }

            return CreatedAtAction(nameof(DeleteDepartment), new { id = id }, dept);
        }
       

    }
}
