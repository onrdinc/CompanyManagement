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

            await _repo.DeleteAsync(user);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
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

        public async Task<ApiResponse<List<ProjectParticipantGetDto>>> GetUsersAsync(params string[] includeList)
        {
            var users = await _repo.GetAllAsync(includeList: includeList);
            if (users.Count > 0)
            {
                var returnList = _mapper.Map<List<ProjectParticipantGetDto>>(users);
                var response = ApiResponse<List<ProjectParticipantGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("Kişiler Bulunamadı");
        }

        public async Task<ApiResponse<ProjectParticipant>> InsertAsync(ProjectParticipantPostDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");
            var user = _mapper.Map<ProjectParticipant>(dto);

            var insertedUser = await _repo.InsertAsync(user);

            return ApiResponse<ProjectParticipant>.Success(StatusCodes.Status201Created, insertedUser);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ProjectParticipantPutDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");
            var user = _mapper.Map<ProjectParticipant>(dto);

            await _repo.UpdateAsync(user);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
