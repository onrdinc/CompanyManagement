﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Project;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class ProjectProfile:Profile
    {
        public ProjectProfile() 
        {
            CreateMap<Project, ProjectGetDto>();
                //.ForMember(dest => dest.Department., opt => opt.MapFrom(src => src.Department.Name))
                //.ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name))
                //.ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Department.Id))
                //.ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.Service.Id));


            CreateMap<ProjectPostDto, Project>();
            CreateMap<ProjectPutDto, Project>();
        }
    }
}
