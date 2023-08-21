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
            CreateMap<Job, JobGetDto>();
            CreateMap<JobPostDto, Job>();
            CreateMap<JobPutDto, Job>();
        }
    }
}
