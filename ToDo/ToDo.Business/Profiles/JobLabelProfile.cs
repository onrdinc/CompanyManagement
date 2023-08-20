using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.JobLabel;
using ToDo.Model.Dto.Project;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class JobLabelProfile : Profile
    {
        public JobLabelProfile()
        {
            CreateMap<JobLabel, JobLabelGetDto>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id))
                .ForMember(dest => dest.LabelId, opt => opt.MapFrom(src => src.Label.Id))
                .ForMember(dest => dest.JobId, opt => opt.MapFrom(src => src.Job.Id));

            CreateMap<JobLabelPostDto, JobLabel>();
            CreateMap<JobLabelPutDto, JobLabel>();
        }
    }
}
