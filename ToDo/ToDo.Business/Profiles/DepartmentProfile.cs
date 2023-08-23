using AutoMapper;
using ToDo.Model.Dto.Department;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile() 
        {
            CreateMap<Department, DepartmentGetDto>();
            CreateMap<DepartmentPostDto, Department>();
            CreateMap<DepartmentPutDto, Department>();
        }
    }
}
