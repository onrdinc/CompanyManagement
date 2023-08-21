using AutoMapper;
using ToDo.Model.Dto.Milestone;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class StatuProfile : Profile
    {
        public StatuProfile()
        {
            CreateMap<Statu, StatuGetDto>();
            CreateMap<StatuPostDto, Statu>();
            CreateMap<StatuPutDto, Statu>();
        }
    }
}
