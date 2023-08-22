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
using ToDo.Model.Dto.Job;
using ToDo.Model.Dto.Project;
using ToDo.Model.Dto.ProjectParticipant;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class ProjectParticipantBs : IProjectParticipantBs
    {
        private readonly IMapper _mapper;
        private readonly IProjectParticipantRepository _repo;

        public ProjectParticipantBs(IProjectParticipantRepository repo,IMapper mapper)
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
                user.IsDeleted = true;
                await _repo.UpdateAsync(user);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen id ye uygun kişi bulunamadı");
        }

        public async Task<ApiResponse<ProjectParticipantGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var user = await _repo.GetByIdAsync(Id, includeList);
            if (user != null)
            {
                var dto = _mapper.Map<ProjectParticipantGetDto>(user);
                return ApiResponse<ProjectParticipantGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Kişi Bulunamadı");
        }

        public async Task<ApiResponse<List<ProjectParticipantGetDto>>> GetByParticipantAsync(int projectId, params string[] includeList)
        {
            if (projectId <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var users = await _repo.GetByParticipantAsync(projectId, includeList);
            //if (users != null && users.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<UserGetDto>>(users);
            //    return ApiResponse<List<UserGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //}
            //throw new NotFoundException("İçerik bulunamadı.");
            var returnList = _mapper.Map<List<ProjectParticipantGetDto>>(users);
            return ApiResponse<List<ProjectParticipantGetDto>>.Success(StatusCodes.Status200OK, returnList);
        }

        public async Task<ApiResponse<List<ProjectParticipantGetDto>>> GetByUserProjectAsync(int userId, params string[] includeList)
        {
            if (userId <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var projects = await _repo.GetByUserProjectAsync(userId, includeList);
            //if (users != null && users.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<UserGetDto>>(users);
            //    return ApiResponse<List<UserGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //}
            //throw new NotFoundException("İçerik bulunamadı.");
            var returnList = _mapper.Map<List<ProjectParticipantGetDto>>(projects);
            return ApiResponse<List<ProjectParticipantGetDto>>.Success(StatusCodes.Status200OK, returnList);
        }

        public async Task<ApiResponse<List<ProjectParticipantGetDto>>> GetUsersAsync(params string[] includeList)
        {
            var users = await _repo.GetAllAsync(k => k.IsDeleted == false, includeList: includeList);
            //if (users.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<ProjectParticipantGetDto>>(users);
            //    var response = ApiResponse<List<ProjectParticipantGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //    return response;
            //}
            //throw new NotFoundException("Kişiler Bulunamadı");
            var returnList = _mapper.Map<List<ProjectParticipantGetDto>>(users);
            var response = ApiResponse<List<ProjectParticipantGetDto>>.Success(StatusCodes.Status200OK, returnList);
            return response;
        }

        public async Task<ApiResponse<ProjectParticipantGetDto>> InsertAsync(ProjectParticipantPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");
            var user = _mapper.Map<ProjectParticipant>(dto);

            var insertedUser = await _repo.InsertAsync(user);
            var retCat = _mapper.Map<ProjectParticipantGetDto>(insertedUser);

            return ApiResponse<ProjectParticipantGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ProjectParticipantPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");
            var user = _mapper.Map<ProjectParticipant>(dto);

            await _repo.UpdateAsync(user);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
