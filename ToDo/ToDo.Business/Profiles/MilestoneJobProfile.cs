using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.MilestoneJob;
using ToDo.Model.Dto.Project;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class MilestoneJobProfile : Profile
    {
        public MilestoneJobProfile()
        {
            CreateMap<MilestoneJob, MilestoneJobGetDto>()
               .ForMember(dest => dest.MilestoneId, opt => opt.MapFrom(src => src.Milestone.Id))
               .ForMember(dest => dest.JobId, opt => opt.MapFrom(src => src.Job.Id));

            CreateMap<MilestoneJobPostDto, MilestoneJob>();
            CreateMap<MilestoneJobPutDto, MilestoneJob>();
        }
    }
}
