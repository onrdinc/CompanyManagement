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
using ToDo.Model.Dto.Company;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class CompanyBs : ICompanyBs
    {
        private readonly ICompanyRepository _repo;
        private readonly IMapper _mapper;

        public CompanyBs(ICompanyRepository repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var company = await _repo.GetByIdAsync(Id);

            await _repo.DeleteAsync(company);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<CompanyGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var company = await _repo.GetByIdAsync(Id, includeList);
            if (company != null)
            {
                var dto = _mapper.Map<CompanyGetDto>(company);
                return ApiResponse<CompanyGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Şirket Bulunamadı");
        }

        public async Task<ApiResponse<List<CompanyGetDto>>> GetCompanysAsync(params string[] includeList)
        {
            var companys = await _repo.GetAllAsync(includeList: includeList);
            if (companys.Count > 0)
            {
                var returnList = _mapper.Map<List<CompanyGetDto>>(companys);
                var response = ApiResponse<List<CompanyGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("Şirketler Bulunamadı");
        }

        public async Task<ApiResponse<Company>> InsertAsync(CompanyPostDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");

            if (dto.CompanyName != null)
                throw new BadRequestException("Şirket Adı Boş Olamaz");

            if (dto.Email != null)
                throw new BadRequestException("Email Boş Olamaz");
            if (dto.Address != null)
                throw new BadRequestException("Adres Boş Olamaz");
            if (dto.Phone != null)
                throw new BadRequestException("Telefon Boş Olamaz");
           
            var company = _mapper.Map<Company>(dto);

            var insertedcompany = await _repo.InsertAsync(company);

            return ApiResponse<Company>.Success(StatusCodes.Status201Created, insertedcompany);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CompanyPutDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");

            if (dto.CompanyName != null)
                throw new BadRequestException("Şirket Adı Boş Olamaz");

            if (dto.Email != null)
                throw new BadRequestException("Email Boş Olamaz");
            if (dto.Address != null)
                throw new BadRequestException("Adres Boş Olamaz");
            if (dto.Phone != null)
                throw new BadRequestException("Telefon Boş Olamaz");

            var company = _mapper.Map<Company>(dto);

            await _repo.UpdateAsync(company);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
