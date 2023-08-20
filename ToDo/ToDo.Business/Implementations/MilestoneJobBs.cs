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
using ToDo.Model.Dto.MilestoneJob;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class MilestoneJobBs : IMilestoneJobBs
    {
        private readonly IMilestoneJobRepository _repo;
        private readonly IMapper _mapper;

        public MilestoneJobBs(IMilestoneJobRepository repo,IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var job = await _repo.GetByIdAsync(Id);

            await _repo.DeleteAsync(job);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<MilestoneJobGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var job = await _repo.GetByIdAsync(Id, includeList);
            if (job != null)
            {
                var dto = _mapper.Map<MilestoneJobGetDto>(job);
                return ApiResponse<MilestoneJobGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İş Bulunamadı");
        }

        public async Task<ApiResponse<List<MilestoneJobGetDto>>> GetMilestoneJobsAsync(params string[] includeList)
        {
            var jobs = await _repo.GetAllAsync(includeList: includeList);
            if (jobs.Count > 0)
            {
                var returnList = _mapper.Map<List<MilestoneJobGetDto>>(jobs);
                var response = ApiResponse<List<MilestoneJobGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İşler Bulunamadı");
        }

        public async Task<ApiResponse<MilestoneJob>> InsertAsync(MilestoneJobPostDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Bilgi yollamalısınız");
            var job = _mapper.Map<MilestoneJob>(dto);

            var insertedUser = await _repo.InsertAsync(job);

            return ApiResponse<MilestoneJob>.Success(StatusCodes.Status201Created, insertedUser);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(MilestoneJobPutDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Bilgi yollamalısınız");

            var job = _mapper.Map<MilestoneJob>(dto);

            await _repo.UpdateAsync(job);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
