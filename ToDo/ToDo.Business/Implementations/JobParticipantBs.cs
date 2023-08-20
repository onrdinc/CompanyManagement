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
using ToDo.Model.Dto.JobParticipant;
using ToDo.Model.Dto.Project;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class JobParticipantBs : IJobParticipantBs
    {
        private readonly IMapper _mapper;
        private readonly IJobParticipantRepository _repo;

        public JobParticipantBs(IJobParticipantRepository repo,IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var user = await _repo.GetByIdAsync(Id);

            await _repo.DeleteAsync(user);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<JobParticipantGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var jp = await _repo.GetByIdAsync(Id, includeList);
            if (jp != null)
            {
                var dto = _mapper.Map<JobParticipantGetDto>(jp);
                return ApiResponse<JobParticipantGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Kayıt Bulunamadı");
        }

        public async Task<ApiResponse<List<JobParticipantGetDto>>> GetUsersAsync(params string[] includeList)
        {
            var users = await _repo.GetAllAsync(includeList: includeList);
            if (users.Count > 0)
            {
                var returnList = _mapper.Map<List<JobParticipantGetDto>>(users);
                var response = ApiResponse<List<JobParticipantGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("Kişiler Bulunamadı");
        }

        public async Task<ApiResponse<JobParticipant>> InsertAsync(JobParticipantPostDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Kaydedilecek bilgi yollamalısınız");
            var user = _mapper.Map<JobParticipant>(dto);

            var insertedUser = await _repo.InsertAsync(user);

            return ApiResponse<JobParticipant>.Success(StatusCodes.Status201Created, insertedUser);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(JobParticipantPutDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Kaydedilecek bilgi yollamalısınız");

            var user = _mapper.Map<JobParticipant>(dto);

            await _repo.UpdateAsync(user);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
