using AutoMapper;
using ToDo.Model.Dto.Service;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceGetDto>();
            CreateMap<ServicePostDto, Service>();
            CreateMap<ServicePutDto, Service>();
        }
    }
}
