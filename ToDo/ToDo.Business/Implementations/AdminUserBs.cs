using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Business.CustomExceptions;
using ToDo.Business.Interfaces;
using ToDo.DataAccess.Interfaces;
using ToDo.Model.Dto.AdminUser;
using ToDo.Model.Dto.User;

namespace ToDo.Business.Implementations
{
    public class AdminUserBs : IAdminUserBs
    {
        private readonly IAdminUserRepository _repo;
        private readonly IMapper _mapper;
        public AdminUserBs(IAdminUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<AdminUserGetDto>> LogIn(string userName, string password, params string[] includeList)
        {
            userName = userName.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                throw new BadRequestException("Kullanıcı Adı Boş Bırakılamaz.");
            }

            if (userName.Length <= 2)
            {
                throw new BadRequestException("Kullanıcı Adı en az 3 karakter olmalıdır.");
            }

            password = password.Trim();
            if (string.IsNullOrEmpty(password))
            {
                throw new BadRequestException("Şifre Boş Bırakılamaz.");
            }

            var adminUser = await _repo.GetByUserNameAndPasswordAsync(userName, password, includeList);

            if (adminUser != null)
            {
                var dto = _mapper.Map<AdminUserGetDto>(adminUser);
                return ApiResponse<AdminUserGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Kullanıcı Bulunamadı.");
        }
    }
}
