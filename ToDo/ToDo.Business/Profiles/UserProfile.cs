using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        { 
            CreateMap<User,UserGetDto>() 
                .ForMember(dest => dest.UserPicture,opt => opt.MapFrom(src => src.Base64Picture))
                .ForMember(dest => dest.DepartmentId,opt => opt.MapFrom(src => src.Department.Id))
                .ForMember(dest => dest.DepartmentName,opt => opt.MapFrom(src => src.Department.Name)); 

            CreateMap<UserPostDto, User>().ForMember(dest=>dest.Picture, opt => opt.MapFrom(src => Convert.FromBase64String(src.PictureBase64)));

            CreateMap<UserPutDto, User>();
        }
    }
}
