
using AutoMapper;
using EmployeesApp.Models.Domain;
using EmployeesApp.Models.DTOs;


namespace EmployeesApp.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<AddEmployeeDto,Employee>().ReverseMap();
            CreateMap<UpdateEmployeeDto,Employee>().ReverseMap();
        }
    }
}
