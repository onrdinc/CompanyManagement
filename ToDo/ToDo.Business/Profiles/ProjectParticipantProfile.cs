using AutoMapper;
using ToDo.Model.Dto.ProjectParticipant;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class ProjectParticipantProfile : Profile
    {
        public ProjectParticipantProfile()
        {
            CreateMap<ProjectParticipant, ProjectParticipantGetDto>()
               .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
               .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id));

            CreateMap<ProjectParticipantPostDto, ProjectParticipant>();
            CreateMap<ProjectParticipantPutDto, ProjectParticipant>();
        }
    }
}
