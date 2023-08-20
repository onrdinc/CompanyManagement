using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Department;
using ToDo.Model.Dto.Project;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile() 
        {
            CreateMap<Department, DepartmentGetDto>()
               .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id));

            CreateMap<DepartmentPostDto, Department>();
            CreateMap<DepartmentPutDto, Department>();
        }
    }
}
