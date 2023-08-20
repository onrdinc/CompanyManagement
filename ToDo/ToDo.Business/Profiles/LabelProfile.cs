using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Label;
using ToDo.Model.Dto.Project;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class LabelProfile : Profile
    {
        public LabelProfile()
        {
            CreateMap<Label, LabelGetDto>()
                 .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id));

            CreateMap<LabelPostDto, Label>();
            CreateMap<LabelPutDto, Label>();
        }
    }
}
