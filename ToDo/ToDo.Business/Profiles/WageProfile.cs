using AutoMapper;
using ToDo.Model.Dto.Wage;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class WageProfile : Profile
    {
        public WageProfile() 
        {
            CreateMap<Wage, WageGetDto>();
            CreateMap<WagePostDto, Wage>();
            CreateMap<WagePutDto, Wage>();
        }
    }
}
