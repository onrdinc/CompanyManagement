using AutoMapper;
using ToDo.Model.Dto.Company;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyGetDto>();
            CreateMap<CompanyPostDto, Company>();
            CreateMap<CompanyPutDto, Company>();
        }
    }
}
