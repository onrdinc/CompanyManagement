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
using ToDo.Model.Dto.Department;
using ToDo.Model.Dto.Wage;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class WageBs : IWageBs
    {
        private readonly IWageRepository _repo;
        private readonly IMapper _mapper;

        public WageBs(IWageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var wage = await _repo.GetByIdAsync(Id);

            if (wage != null)
            {
                wage.IsDeleted = true;
                await _repo.UpdateAsync(wage);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen id ye uygun ücretlendirme bulunamadı");
        }

        public async Task<ApiResponse<WageGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var wage = await _repo.GetByIdAsync(Id, includeList);
            if (wage != null)
            {
                var dto = _mapper.Map<WageGetDto>(wage);
                return ApiResponse<WageGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Ücretlendirme Bulunamadı");
        }

        public async Task<ApiResponse<List<WageGetDto>>> GetWagesAsync(params string[] includeList)
        {
            var wages = await _repo.GetAllAsync(k => k.IsDeleted == false, includeList: includeList);
            //if (departments.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<DepartmentGetDto>>(departments);
            //    var response = ApiResponse<List<DepartmentGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //    return response;
            //}
            //throw new NotFoundException("Kişiler Bulunamadı");
            var returnList = _mapper.Map<List<WageGetDto>>(wages);
            var response = ApiResponse<List<WageGetDto>>.Success(StatusCodes.Status200OK, returnList);
            return response;
        }

        public async Task<ApiResponse<WageGetDto>> InsertAsync(WagePostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek departman bilgisi yollamalısınız");

            if (dto.Amount == null)
                throw new BadRequestException("Ücret Adı Boş Olamaz");

            if (dto.UserId == null)
                throw new BadRequestException("Kişi  Boş Olamaz");

            var wage = _mapper.Map<Wage>(dto);

            var insertedWage = await _repo.InsertAsync(wage);
            var retCat = _mapper.Map<WageGetDto>(insertedWage);

            return ApiResponse<WageGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(WagePutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek departman bilgisi yollamalısınız");

            if (dto.Amount == null)
                throw new BadRequestException("Ücret Adı Boş Olamaz");

            if (dto.UserId == null)
                throw new BadRequestException("Kişi  Boş Olamaz");
            var wage = _mapper.Map<Wage>(dto);

            await _repo.UpdateAsync(wage);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
