using AutoMapper;
using ToDo.Model.Dto.Milestone;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class MilestoneProfile : Profile
    {
        public MilestoneProfile()
        {
            CreateMap<Milestone, MilestoneGetDto>()
              .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id));
          

            CreateMap<MilestonePostDto, Milestone>();
            CreateMap<MilestonePutDto, Milestone>();
        }
    }
}
