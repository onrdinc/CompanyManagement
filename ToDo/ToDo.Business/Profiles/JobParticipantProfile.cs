using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.JobParticipant;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class JobParticipantProfile : Profile
    {
        public JobParticipantProfile()
        {
            CreateMap<JobParticipant, JobParticipantGetDto>()
   .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id))
   .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
   .ForMember(dest => dest.JobId, opt => opt.MapFrom(src => src.Job.Id));

            CreateMap<JobParticipantPostDto, JobParticipant>();
            CreateMap<JobParticipantPutDto, JobParticipant>();
        }
    }
}
