﻿using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using ToDo.Business.CustomExceptions;
using ToDo.Business.Interfaces;
using ToDo.DataAccess.Interfaces;
using ToDo.Model.Dto.Department;
using ToDo.Model.Dto.Service;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class ServiceBs : IServiceBs
    {
        private readonly IServiceRepository _repo;
        private readonly IMapper _mapper;

        public ServiceBs(IServiceRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var service = await _repo.GetByIdAsync(Id);
            if(service != null)
            {
                service.IsDeleted =true;
                await _repo.UpdateAsync(service);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen id ye uygun hizmet bulunamadı");


        }

        public async Task<ApiResponse<ServiceGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var service = await _repo.GetByIdAsync(Id, includeList);
            if (service != null)
            {
                var dto = _mapper.Map<ServiceGetDto>(service);
                return ApiResponse<ServiceGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Hizmet Bulunamadı");
        }

        public async Task<ApiResponse<List<ServiceGetDto>>> GetServicesAsync(params string[] includeList)
        {
            var services = await _repo.GetAllAsync(k=>k.IsDeleted == false ,includeList: includeList);
            //if (services.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<ServiceGetDto>>(services);
            //    var response = ApiResponse<List<ServiceGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //    return response;
            //}
            //throw new NotFoundException("Hizmet Bulunamadı");
            var returnList = _mapper.Map<List<ServiceGetDto>>(services);
            var response = ApiResponse<List<ServiceGetDto>>.Success(StatusCodes.Status200OK, returnList);
            return response;
        }

        public async Task<ApiResponse<ServiceGetDto>> InsertAsync(ServicePostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek hizmet bilgisi yollamalısınız");

            if (dto.Name == null)
                throw new BadRequestException("Hizmet Adı Boş Olamaz");

            var department = _mapper.Map<Service>(dto);

            var insertedService = await _repo.InsertAsync(department);
            var srv = _mapper.Map<ServiceGetDto>(insertedService);

            return ApiResponse<ServiceGetDto>.Success(StatusCodes.Status201Created, srv);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ServicePutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek hizmet bilgisi yollamalısınız");

            if (dto.Name == null)
                throw new BadRequestException("Hizmet Adı Boş Olamaz");

            var department = _mapper.Map<Service>(dto);

            await _repo.UpdateAsync(department);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
