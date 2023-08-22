using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using ToDo.Business.CustomExceptions;
using ToDo.Business.Interfaces;
using ToDo.DataAccess.Interfaces;
using ToDo.Model.Dto.Job;
using ToDo.Model.Dto.Milestone;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class JobBs : IJobBs
    {
        private readonly IJobRepository _repo;
        private readonly IMapper _mapper;

        public JobBs(IJobRepository repo, IMapper mapper)
        {

            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var job = await _repo.GetByIdAsync(Id);

            await _repo.DeleteAsync(job);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<JobGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var user = await _repo.GetByIdAsync(Id, includeList);
            if (user != null)
            {
                var dto = _mapper.Map<JobGetDto>(user);
                return ApiResponse<JobGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İş Bulunamadı");
        }

        public async Task<ApiResponse<List<JobGetDto>>> GetByProjectJobAsync(int projectId, params string[] includeList)
        {
            if (projectId <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var users = await _repo.GetByProjectJobAsync(projectId, includeList);
            //if (users != null && users.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<UserGetDto>>(users);
            //    return ApiResponse<List<UserGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //}
            //throw new NotFoundException("İçerik bulunamadı.");
            var returnList = _mapper.Map<List<JobGetDto>>(users);
            return ApiResponse<List<JobGetDto>>.Success(StatusCodes.Status200OK, returnList);
        }

        public async Task<ApiResponse<List<JobGetDto>>> GetJobsAsync(params string[] includeList)
        {
            var jobs = await _repo.GetAllAsync(includeList: includeList);
            //if (jobs.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<JobGetDto>>(jobs);
            //    var response = ApiResponse<List<JobGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //    return response;
            //}
            //throw new NotFoundException("İşler Bulunamadı");
            var returnList = _mapper.Map<List<JobGetDto>>(jobs);
            var response = ApiResponse<List<JobGetDto>>.Success(StatusCodes.Status200OK, returnList);
            return response;
        }

        public async Task<ApiResponse<JobGetDto>> InsertAsync(JobPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek iş bilgisi yollamalısınız");

            if (dto.Detail == null)
                throw new BadRequestException("İş Detayı Boş Olamaz");

            if (dto.JobTitle == null)
                throw new BadRequestException("İş Adı Boş Olamaz");
           

            var job = _mapper.Map<Job>(dto);

            var insertedJob = await _repo.InsertAsync(job);
            var retCat = _mapper.Map<JobGetDto>(insertedJob);


            return ApiResponse<JobGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(JobPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek iş bilgisi yollamalısınız");

            if (dto.Detail == null)
                throw new BadRequestException("İş Detayı Boş Olamaz");

            if (dto.JobTitle == null)
                throw new BadRequestException("İş Adı Boş Olamaz");

            var job = _mapper.Map<Job>(dto);

            await _repo.UpdateAsync(job);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
