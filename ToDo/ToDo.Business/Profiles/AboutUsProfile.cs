using AutoMapper;
using ToDo.Model.Dto.AboutUs;
using ToDo.Model.Dto.Department;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class AboutUsProfile : Profile
    {
        public AboutUsProfile()
        {
            CreateMap<AboutUs, AboutUsGetDto>();
            CreateMap<AboutUsPostDto, AboutUs>();
            CreateMap<AboutUsPutDto, AboutUs>();
        }
    }
}
