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
using ToDo.Model.Dto.Label;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class LabelBs : ILabelBs
    {
        private readonly ILabelRepository _repo;
        private readonly IMapper _mapper;

        public LabelBs(ILabelRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var label = await _repo.GetByIdAsync(Id);

            await _repo.DeleteAsync(label);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<LabelGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var label = await _repo.GetByIdAsync(Id, includeList);
            if (label != null)
            {
                var dto = _mapper.Map<LabelGetDto>(label);
                return ApiResponse<LabelGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Etiket Bulunamadı");
        }

        public async Task<ApiResponse<List<LabelGetDto>>> GetLabelsAsync(params string[] includeList)
        {
            var labels = await _repo.GetAllAsync(includeList: includeList);

            //if (labels.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<LabelGetDto>>(labels);
            //    var response = ApiResponse<List<LabelGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //    return response;
            //}
            //throw new NotFoundException("Etiketler Bulunamadı");
            var returnList = _mapper.Map<List<LabelGetDto>>(labels);
            var response = ApiResponse<List<LabelGetDto>>.Success(StatusCodes.Status200OK, returnList);
            return response;
        }

        public async Task<ApiResponse<LabelGetDto>> InsertAsync(LabelPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek etiket bilgisi yollamalısınız");

            if (dto.Name == null)
                throw new BadRequestException("İsim Boş Olamaz");

            var label = _mapper.Map<Label>(dto);

            var insertedLabel = await _repo.InsertAsync(label);
            var retCat = _mapper.Map<LabelGetDto>(insertedLabel);

            return ApiResponse<LabelGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(LabelPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek etiket bilgisi yollamalısınız");

            if (dto.Name == null)
                throw new BadRequestException("İsim Boş Olamaz");

            var label = _mapper.Map<Label>(dto);

            await _repo.UpdateAsync(label);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}










