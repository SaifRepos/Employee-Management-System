using AutoMapper;
using Employe_Management_System.Dto;
using Employe_Management_System.Models;

namespace Employe_Management_System
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DepartmentDto, Department>().ReverseMap();
            CreateMap<EmployeeDto, Employee>().ReverseMap();


        }
    }
}
