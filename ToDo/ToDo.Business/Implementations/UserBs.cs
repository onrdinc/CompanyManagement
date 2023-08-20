﻿using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using ToDo.Business.CustomExceptions;
using ToDo.Business.Interfaces;
using ToDo.DataAccess.Interfaces;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class UserBs : IUserBs
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UserBs(IUserRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var user = await _repo.GetByIdAsync(Id);
            if(user != null)
            {
                //user.IsDeleted = true;
                //await _repo.UpdateAsync(user);
                await _repo.DeleteAsync(user);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Kullanıcı Bulunamadı");
        }

        public async Task<ApiResponse<UserGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var user = await _repo.GetByIdAsync(Id , includeList);
            if(user != null)
            {
                var dto = _mapper.Map<UserGetDto>(user);
                return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK,dto);
            }
            throw new NotFoundException("Kişi Bulunamadı");

        }

        public async Task<ApiResponse<List<UserGetDto>>> GetUsersAsync(params string[] includeList)
        {
            var users = await _repo.GetAllAsync(includeList : includeList);
            if (users.Count > 0)
            {
                var returnList = _mapper.Map<List<UserGetDto>>(users);
                var response = ApiResponse<List<UserGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("Kişiler Bulunamadı");

        }

        public async Task<ApiResponse<UserGetDto>> InsertAsync(UserPostDto dto)
        {
            //if (dto != null)
            //    throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");

            //if (dto.Name != null)
            //    throw new BadRequestException("İsim Boş Olamaz");

            //if (dto.Surname != null)
            //    throw new BadRequestException("Soyisim Boş Olamaz");
            //if (dto.Email != null)
            //    throw new BadRequestException("Email Boş Olamaz");
            //if (dto.Password != null)
            //    throw new BadRequestException("Şifre Boş Olamaz");
            //if (dto.Nickname != null)
            //    throw new BadRequestException("Kullanıcı Adı Boş Olamaz");

            var user = _mapper.Map<User>(dto);

            var insertedUser = await _repo.InsertAsync(user);

            var retCat = _mapper.Map<UserGetDto>(insertedUser);

            return ApiResponse<UserGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(UserPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");

            if (dto.Name == null)
                throw new BadRequestException("İsim Boş Olamaz");

            if (dto.Surname == null)
                throw new BadRequestException("Soyisim Boş Olamaz");
            if (dto.Email == null)
                throw new BadRequestException("Email Boş Olamaz");
            //if (dto.Password != null)
            //    throw new BadRequestException("Şifre Boş Olamaz");
            //if (dto.Nickname != null)
            //    throw new BadRequestException("Kullanıcı Adı Boş Olamaz");

            var user = _mapper.Map<User>(dto);

            await _repo.UpdateAsync(user);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
