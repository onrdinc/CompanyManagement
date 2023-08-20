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
using ToDo.Model.Dto.JobLabel;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class JobLabelBs : IJobLabelBs
    {
        private readonly IJobLabelRepository _repo;
        private readonly IMapper _mapper;
        public JobLabelBs(IJobLabelRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var jobLabel = await _repo.GetByIdAsync(Id);

            await _repo.DeleteAsync(jobLabel);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<JobLabelGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var jobLabel = await _repo.GetByIdAsync(Id, includeList);
            if (jobLabel != null)
            {
                var dto = _mapper.Map<JobLabelGetDto>(jobLabel);
                return ApiResponse<JobLabelGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Kayıt Bulunamadı");
        }

        public async Task<ApiResponse<List<JobLabelGetDto>>> GetJobLabelsAsync(params string[] includeList)
        {
            var jobLabels = await _repo.GetAllAsync(includeList: includeList);
            if (jobLabels.Count > 0)
            {
                var returnList = _mapper.Map<List<JobLabelGetDto>>(jobLabels);
                var response = ApiResponse<List<JobLabelGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("Kayıtlar Bulunamadı");
        }

        public async Task<ApiResponse<JobLabel>> InsertAsync(JobLabelPostDto dto)
        {
            var jobLabel = _mapper.Map<JobLabel>(dto);

            var insertedjobLabels = await _repo.InsertAsync(jobLabel);

            return ApiResponse<JobLabel>.Success(StatusCodes.Status201Created, insertedjobLabels);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(JobLabelPutDto dto)
        {
            var jobLabel = _mapper.Map<JobLabel>(dto);

            await _repo.UpdateAsync(jobLabel);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
