﻿using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using ToDo.Business.CustomExceptions;
using ToDo.Business.Interfaces;
using ToDo.DataAccess.Interfaces;
using ToDo.Model.Dto.Project;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class ProjectBs : IProjectBs
    {
        private readonly IProjectRepository _repo;
        private readonly IMapper _mapper;
        public ProjectBs(IProjectRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var project = await _repo.GetByIdAsync(Id);
            if(project !=null)
            {
                project.IsDeleted = true;
                await _repo.UpdateAsync(project);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen id ye uygun proje bulunamadı");
        }

        public async Task<ApiResponse<ProjectGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var project = await _repo.GetByIdAsync(Id, includeList);
            if (project != null)
            {
                var dto = _mapper.Map<ProjectGetDto>(project);
                return ApiResponse<ProjectGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Proje Bulunamadı");
        }

        public async Task<ApiResponse<List<ProjectGetDto>>> GetByProjectDepartmentAsync(int departmentId, params string[] includeList)
        {
            if (departmentId <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var users = await _repo.GetByProjectDepartmentAsync(departmentId, includeList);
            //if (users != null && users.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<UserGetDto>>(users);
            //    return ApiResponse<List<UserGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //}
            //throw new NotFoundException("İçerik bulunamadı.");
            var returnList = _mapper.Map<List<ProjectGetDto>>(users);
            return ApiResponse<List<ProjectGetDto>>.Success(StatusCodes.Status200OK, returnList);
        }

        public async Task<ApiResponse<List<ProjectGetDto>>> GetByProjectServiceAsync(int serviceId, params string[] includeList)
        {
            if (serviceId <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var users = await _repo.GetByProjectServiceAsync(serviceId, includeList);
            //if (users != null && users.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<UserGetDto>>(users);
            //    return ApiResponse<List<UserGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //}
            //throw new NotFoundException("İçerik bulunamadı.");
            var returnList = _mapper.Map<List<ProjectGetDto>>(users);
            return ApiResponse<List<ProjectGetDto>>.Success(StatusCodes.Status200OK, returnList);
        }

        public async Task<ApiResponse<List<ProjectGetDto>>> GetProjectsAsync(params string[] includeList)
        {
            var projects = await _repo.GetAllAsync(k => k.IsDeleted == false, includeList: includeList);
            //if (projects.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<ProjectGetDto>>(projects);
            //    var response = ApiResponse<List<ProjectGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //    return response;
            //}
            //throw new NotFoundException("Projeler Bulunamadı");
            var returnList = _mapper.Map<List<ProjectGetDto>>(projects);
            var response = ApiResponse<List<ProjectGetDto>>.Success(StatusCodes.Status200OK, returnList);
            return response;
        }

        public async Task<ApiResponse<ProjectGetDto>> InsertAsync(ProjectPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");
            if (dto.Name == null)
                throw new BadRequestException("Proje Adı Olamaz");
            if (dto.ServiceId == null)
                throw new BadRequestException("Lütfen Hizmet Alanı Seçiniz");
            if (dto.DepartmentId == null)
                throw new BadRequestException("Lütfen Departman Seçiniz");
           

            var project = _mapper.Map<Project>(dto);

            var insertedProject = await _repo.InsertAsync(project);
            var prj = _mapper.Map<ProjectGetDto>(insertedProject);


            return ApiResponse<ProjectGetDto>.Success(StatusCodes.Status201Created, prj);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ProjectPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek kişi bilgisi yollamalısınız");

            if (dto.Name == null)
                throw new BadRequestException("Proje Adı Olamaz");
            if (dto.ServiceId == null)
                throw new BadRequestException("Lütfen Hizmet Alanı Seçiniz");
            if (dto.DepartmentId == null)
                throw new BadRequestException("Lütfen Departman Seçiniz");

            var project = _mapper.Map<Project>(dto);

            await _repo.UpdateAsync(project);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
