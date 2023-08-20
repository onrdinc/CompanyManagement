using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Job;
using ToDo.Model.Dto.Project;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class JobProfile : Profile
    {
        public JobProfile() 
        {
            CreateMap<Job, JobGetDto>()
               .ForMember(dest => dest.MilestoneId, opt => opt.MapFrom(src => src.Milestone.Id))
               .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id));

            CreateMap<JobPostDto, Job>();
            CreateMap<JobPutDto, Job>();
        }
    }
}
