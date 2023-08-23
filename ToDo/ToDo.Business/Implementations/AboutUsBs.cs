using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using ToDo.Business.CustomExceptions;
using ToDo.Business.Interfaces;
using ToDo.DataAccess.Interfaces;
using ToDo.Model.Dto.AboutUs;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class AboutUsBs : IAboutUsBs
    {
        private readonly IAboutUsRepository _repo;
        private readonly IMapper _mapper;

        public AboutUsBs(IAboutUsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var about = await _repo.GetByIdAsync(Id);

            if (about != null)
            {
                about.IsDeleted = true;
                await _repo.UpdateAsync(about);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen id ye uygun bilgi bulunamadı");
        }

        public async Task<ApiResponse<List<AboutUsGetDto>>> GetAboutUsAsync(params string[] includeList)
        {
            var about = await _repo.GetAllAsync(k => k.IsDeleted == false, includeList: includeList);
 
            var returnList = _mapper.Map<List<AboutUsGetDto>>(about);
            var response = ApiResponse<List<AboutUsGetDto>>.Success(StatusCodes.Status200OK, returnList);
            return response;
        }

        public async Task<ApiResponse<AboutUsGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var about = await _repo.GetByIdAsync(Id, includeList);
            if (about != null)
            {
                var dto = _mapper.Map<AboutUsGetDto>(about);
                return ApiResponse<AboutUsGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Bilgi Bulunamadı");
        }

        public async Task<ApiResponse<AboutUsGetDto>> InsertAsync(AboutUsPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek hakkımızda bilgisi yollamalısınız");

            if (dto.About == null)
                throw new BadRequestException("Hakkımızda Boş Olamaz");

            var about = _mapper.Map<AboutUs>(dto);

            var insertedabout = await _repo.InsertAsync(about);
            var a = _mapper.Map<AboutUsGetDto>(insertedabout);

            return ApiResponse<AboutUsGetDto>.Success(StatusCodes.Status201Created, a);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(AboutUsPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek hakkımızda bilgisi yollamalısınız");

            if (dto.About == null)
                throw new BadRequestException("Hakkımızda Boş Olamaz");

            var about = _mapper.Map<AboutUs>(dto);

            await _repo.UpdateAsync(about);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
