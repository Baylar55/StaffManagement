using StaffManagement.Application.Features.Commands.Department.CreateDepartment;
using StaffManagement.Application.Features.Commands.Employee.CreateEmployee;
using StaffManagement.Application.Features.Queries.Company.GetAll;
using StaffManagement.Application.Features.Queries.Company.GetById;
using StaffManagement.Application.Features.Queries.Department.GetAll;
using StaffManagement.Application.Features.Queries.Department.GetById;
using StaffManagement.Application.Features.Queries.Employee.GetAll;
using StaffManagement.Application.Features.Queries.Employee.GetById;
using StaffManagement.Domain.Entities;

namespace StaffManagement.Application.MappingProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Company, GetAllCompaniesQueryResponse>().ReverseMap();
            CreateMap<Company, GetCompanyByIdQueryResponse>().ReverseMap();
            
            CreateMap<CreateDepartmentCommandRequest, Department>();
            CreateMap<Department, GetAllDepartmentsQueryResponse>().ReverseMap();
            CreateMap<Department, GetDepartmentByIdQueryResponse>().ReverseMap();
            
            CreateMap<CreateEmployeeCommandRequest, Employee>();
            CreateMap<Employee, GetAllEmployeesQueryResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Department.Company.Name));
            CreateMap<Employee, GetEmployeeByIdQueryResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Department.Company.Name));
        }
    }
}
