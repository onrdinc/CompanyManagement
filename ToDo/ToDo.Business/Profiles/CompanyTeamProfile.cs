using AutoMapper;
using ToDo.Model.Dto.CompanyTeam;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class CompanyTeamProfile : Profile
    {
        public CompanyTeamProfile() 
        {
            CreateMap<CompanyTeam, CompanyTeamGetDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id));

            CreateMap<CompanyTeam, CompanyTeamGetDto>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Department.Id));

            CreateMap<CompanyTeam, CompanyTeamGetDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));

            CreateMap<CompanyTeamPostDto, CompanyTeam>();
            CreateMap<CompanyTeamPutDto, CompanyTeam>();
        }
    }
}
