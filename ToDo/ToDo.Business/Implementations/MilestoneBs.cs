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
using ToDo.Model.Dto.Milestone;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class MilestoneBs : IMilestoneBs
    {
        private readonly IMilestoneRepository _repo;
        private readonly IMapper _mapper;

        public MilestoneBs(IMilestoneRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var milestone = await _repo.GetByIdAsync(Id);

            await _repo.DeleteAsync(milestone);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<MilestoneGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var milestone = await _repo.GetByIdAsync(Id, includeList);
            if (milestone != null)
            {
                var dto = _mapper.Map<MilestoneGetDto>(milestone);
                return ApiResponse<MilestoneGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Kilometre Taşı Bulunamadı");
        }

        public async Task<ApiResponse<List<MilestoneGetDto>>> GetMilestonesAsync(params string[] includeList)
        {
            var milestones = await _repo.GetAllAsync(includeList: includeList);
            if (milestones.Count > 0)
            {
                var returnList = _mapper.Map<List<MilestoneGetDto>>(milestones);
                var response = ApiResponse<List<MilestoneGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("Kilometre Taşları Bulunamadı");
        }

        public async Task<ApiResponse<Milestone>> InsertAsync(MilestonePostDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");

            if (dto.Name != null)
                throw new BadRequestException("İsim Boş Olamaz");

            

            var milestone = _mapper.Map<Milestone>(dto);

            var insertedmilestone = await _repo.InsertAsync(milestone);

            return ApiResponse<Milestone>.Success(StatusCodes.Status201Created, insertedmilestone);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(MilestonePutDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");

            if (dto.Name != null)
                throw new BadRequestException("İsim Boş Olamaz");

            var milestone = _mapper.Map<Milestone>(dto);

            await _repo.UpdateAsync(milestone);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
