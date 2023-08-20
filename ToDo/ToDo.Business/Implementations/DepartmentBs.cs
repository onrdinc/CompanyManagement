﻿using AutoMapper;
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

            await _repo.DeleteAsync(department);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
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
            var departments = await _repo.GetAllAsync(includeList: includeList);
            if (departments.Count > 0)
            {
                var returnList = _mapper.Map<List<DepartmentGetDto>>(departments);
                var response = ApiResponse<List<DepartmentGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("Kişiler Bulunamadı");
        }

        public async Task<ApiResponse<Department>> InsertAsync(DepartmentPostDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Kaydedilecek departman bilgisi yollamalısınız");

            if (dto.Name != null)
                throw new BadRequestException("Departman Adı Boş Olamaz");

            if (dto.CompanyId != null)
                throw new BadRequestException("Lütfen Şirket Seçiniz");
           

            var department = _mapper.Map<Department>(dto);

            var insertedDepartment = await _repo.InsertAsync(department);

            return ApiResponse<Department>.Success(StatusCodes.Status201Created, insertedDepartment);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(DepartmentPutDto dto)
        {
            if (dto != null)
                throw new BadRequestException("Kaydedilecek departman bilgisi yollamalısınız");

            if (dto.Name != null)
                throw new BadRequestException("Departman Adı Boş Olamaz");

            if (dto.CompanyId != null)
                throw new BadRequestException("Lütfen Şirket Seçiniz");

            var department = _mapper.Map<Department>(dto);

            await _repo.UpdateAsync(department);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
