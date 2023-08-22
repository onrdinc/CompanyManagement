using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using ToDo.Business.CustomExceptions;
using ToDo.Business.Interfaces;
using ToDo.DataAccess.Interfaces;
using ToDo.Model.Dto.Milestone;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class StatuBs : IStatuBs
    {
        private readonly IStatuRepository _repo;
        private readonly IMapper _mapper;

        public StatuBs(IStatuRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var statu = await _repo.GetByIdAsync(Id);
            if (statu != null)
            {
                statu.IsDeleted = true;
                await _repo.UpdateAsync(statu);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen id ye uygun süreç bulunamadı");


        }

        public async Task<ApiResponse<StatuGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var statu = await _repo.GetByIdAsync(Id, includeList);
            if (statu != null)
            {
                var dto = _mapper.Map<StatuGetDto>(statu);
                return ApiResponse<StatuGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Kilometre Taşı Bulunamadı");
        }

        public async Task<ApiResponse<List<StatuGetDto>>> GetStatusAsync(params string[] includeList)
        {
            var status = await _repo.GetAllAsync(k=>k.IsDeleted == false ,includeList: includeList);
            //if (status.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<StatuGetDto>>(status);
            //    var response = ApiResponse<List<StatuGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //    return response;
            //}
            //throw new NotFoundException("Kilometre Taşları Bulunamadı");
            var returnList = _mapper.Map<List<StatuGetDto>>(status);
            var response = ApiResponse<List<StatuGetDto>>.Success(StatusCodes.Status200OK, returnList);
            return response;
        }

        public async Task<ApiResponse<StatuGetDto>> InsertAsync(StatuPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");

            if (dto.Name == null)
                throw new BadRequestException("İsim Boş Olamaz");

            

            var statu = _mapper.Map<Statu>(dto);

            var insertedstatu = await _repo.InsertAsync(statu);
            var retCat = _mapper.Map<StatuGetDto>(insertedstatu);

            return ApiResponse<StatuGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(StatuPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");

            if (dto.Name == null)
                throw new BadRequestException("İsim Boş Olamaz");

            var statu = _mapper.Map<Statu>(dto);

            await _repo.UpdateAsync(statu);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
