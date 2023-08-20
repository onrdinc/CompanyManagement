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
using ToDo.Model.Dto.CompanyTeam;
using ToDo.Model.Dto.Department;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class CompanyTeamBs : ICompanyTeamBs
    {
        private readonly ICompanyTeamRepository _repo;
        private readonly IMapper _mapper;

        public CompanyTeamBs(ICompanyTeamRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var companyTeam = await _repo.GetByIdAsync(Id);

            await _repo.DeleteAsync(companyTeam);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<CompanyTeamGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var companyTeam = await _repo.GetByIdAsync(Id, includeList);
            if (companyTeam != null)
            {
                var dto = _mapper.Map<CompanyTeamGetDto>(companyTeam);
                return ApiResponse<CompanyTeamGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Şirket Üyesi Bulunamadı.");
        }

        public async Task<ApiResponse<List<CompanyTeamGetDto>>> GetCompanyTeamsAsync(params string[] includeList)
        {
            var companyTeams = await _repo.GetAllAsync(includeList: includeList);
            if (companyTeams.Count > 0)
            {
                var returnList = _mapper.Map<List<CompanyTeamGetDto>>(companyTeams);
                var response = ApiResponse<List<CompanyTeamGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("Kişiler Bulunamadı");
        }

        public async Task<ApiResponse<CompanyTeam>> InsertAsync(CompanyTeamPostDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Kaydedilecek departman bilgisi yollamalısınız");

            if (dto.UserId != null)
                throw new BadRequestException("Kişi Seçmediniz!");

            if (dto.CompanyId != null)
                throw new BadRequestException("Lütfen Şirket Seçiniz");
            if (dto.DepartmentId != null)
                throw new BadRequestException("Lütfen Departman Seçiniz");


            var companyTeam = _mapper.Map<CompanyTeam>(dto);

            var insertedcompanyTeam = await _repo.InsertAsync(companyTeam);

            return ApiResponse<CompanyTeam>.Success(StatusCodes.Status201Created, insertedcompanyTeam);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CompanyTeamPutDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Kaydedilecek departman bilgisi yollamalısınız");

            if (dto.UserId != null)
                throw new BadRequestException("Kişi Seçmediniz!");

            if (dto.CompanyId != null)
                throw new BadRequestException("Lütfen Şirket Seçiniz");
            if (dto.DepartmentId != null)
                throw new BadRequestException("Lütfen Departman Seçiniz");
            var companyTeam = _mapper.Map<CompanyTeam>(dto);

            await _repo.UpdateAsync(companyTeam);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
