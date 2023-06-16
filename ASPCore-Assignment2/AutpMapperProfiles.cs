using ASPCore_Assignment2.Models;
using ASPCore_Assignment2.Models.DTO;
using AutoMapper;

namespace ASPCore_Assignment2
{
    public class AutpMapperProfiles:Profile
    {
        public AutpMapperProfiles()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();
            CreateMap<Employee, AddEmployeeDto>().ReverseMap();
            CreateMap<Employee,EmployeeDto>().ReverseMap();
            CreateMap<Employee,UpdateEmployeeDto>().ReverseMap();
            

            
        }
    }
}
