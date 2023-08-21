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
            CreateMap<Label, LabelGetDto>();
            CreateMap<LabelPostDto, Label>();
            CreateMap<LabelPutDto, Label>();
        }
    }
}
