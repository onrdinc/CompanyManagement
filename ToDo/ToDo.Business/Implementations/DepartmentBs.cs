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
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class DepartmentBs : IDepartmentBs
    {
        private readonly IDepartmentRepository _repo;
        private readonly IMapper _mapper;

        public DepartmentBs(IDepartmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var department = await _repo.GetByIdAsync(Id);

            if (department != null)
            {
                department.IsDeleted = true;
                await _repo.UpdateAsync(department);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen id ye uygun departman bulunamadı");

        }

        public async Task<ApiResponse<DepartmentGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var department = await _repo.GetByIdAsync(Id, includeList);
            if (department != null)
            {
                var dto = _mapper.Map<DepartmentGetDto>(department);
                return ApiResponse<DepartmentGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Departman Bulunamadı");
        }

        public async Task<ApiResponse<List<DepartmentGetDto>>> GetDepartmentsAsync(params string[] includeList)
        {
            var departments = await _repo.GetAllAsync(k=>k.IsDeleted == false,includeList: includeList);
            //if (departments.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<DepartmentGetDto>>(departments);
            //    var response = ApiResponse<List<DepartmentGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //    return response;
            //}
            //throw new NotFoundException("Kişiler Bulunamadı");
            var returnList = _mapper.Map<List<DepartmentGetDto>>(departments);
            var response = ApiResponse<List<DepartmentGetDto>>.Success(StatusCodes.Status200OK, returnList);
            return response;
        }

        public async Task<ApiResponse<DepartmentGetDto>> InsertAsync(DepartmentPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek departman bilgisi yollamalısınız");

            if (dto.Name == null)
                throw new BadRequestException("Departman Adı Boş Olamaz");

            var department = _mapper.Map<Department>(dto);

            var insertedDepartment = await _repo.InsertAsync(department);
            var retCat = _mapper.Map<DepartmentGetDto>(insertedDepartment);

            return ApiResponse<DepartmentGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(DepartmentPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek departman bilgisi yollamalısınız");

            if (dto.Name == null)
                throw new BadRequestException("Departman Adı Boş Olamaz");

            var department = _mapper.Map<Department>(dto);

            await _repo.UpdateAsync(department);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
