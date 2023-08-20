using AutoMapper;
using ToDo.Model.Dto.AdminUser;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    internal class AdminUserProfile : Profile
    {
        public AdminUserProfile()
        {
            CreateMap<AdminUser, AdminUserGetDto>();
        }
    }
}
