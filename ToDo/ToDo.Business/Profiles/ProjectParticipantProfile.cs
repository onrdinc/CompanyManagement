using AutoMapper;
using ToDo.Model.Dto.ProjectParticipant;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class ProjectParticipantProfile : Profile
    {
        public ProjectParticipantProfile()
        {
            CreateMap<ProjectParticipant, ProjectParticipantGetDto>();
            CreateMap<ProjectParticipantPostDto, ProjectParticipant>();
            CreateMap<ProjectParticipantPutDto, ProjectParticipant>();
        }
    }
}
