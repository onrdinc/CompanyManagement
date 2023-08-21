using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ToDo.MvcUI.Areas.Admin.Extensions;
using ToDo.MvcUI.Areas.Admin.Filters;
using ToDo.MvcUI.Areas.Admin.HttpApiServices;
using ToDo.MvcUI.Areas.Admin.Models;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.DepartmentDtos;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.ProjectDtos;
using ToDo.MvcUI.Areas.Admin.ViewModels;

namespace ToDo.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class ProjectController : Controller
    {

        private readonly IHttpApiService _httpApiService;
        public ProjectController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var serviceResponse = await _httpApiService.GetData<ResponseBody<List<ServiceItem>>>("/service", token.Token);
            var departmentResponse = await _httpApiService.GetData<ResponseBody<List<DepartmentItem>>>("/department", token.Token);

            //var projectResponse = await _httpApiService.GetData<ResponseBody<List<ProjectItem>>>("/project", token.Token);

            var projectResponse = id == null
            ? await _httpApiService.GetData<ResponseBody<List<ProjectItem>>>("/project", token.Token)
            : await _httpApiService.GetData<ResponseBody<List<ProjectItem>>>($"/project/getByServiceId?id={id}", token.Token);
            ProjectViewModel vm = new ProjectViewModel();
            vm.Departments = departmentResponse.Data;
            vm.Services = serviceResponse.Data;
            vm.Projects = projectResponse.Data;
            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> GetProject(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response =
              await _httpApiService.GetData<ResponseBody<ProjectItem>>($"/project/{id}", token.Token);

            return Json(new { Name = response.Data.Name, Description = response.Data.Description, DepartmentId = response.Data.Department.Id, ServiceId = response.Data.Service.Id, DepartmentName = response.Data.Department.Name, ServiceName = response.Data.Service.Name });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/project/{id}", token.Token);

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }

        public async Task<IActionResult> Save(NewProjectDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            //anonim nesne
            var postObj = new
            {
                Name = dto.Name,
                Description = dto.Description,
                DepartmentId = dto.DepartmentId,
                ServiceId = dto.ServiceId,

            };

            var response = await _httpApiService.PostData<ResponseBody<ProjectItem>>("/project", JsonSerializer.Serialize(postObj), token.Token);

            //ya da response.statuscode == 201
            if (response.StatusCode.ToString().StartsWith("2"))
            {
                return Json(new { IsSuccess = true, Message = "Başarıyla Kaydedildi", Id = response.Data.Id });

            }
            else
            {
                return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
            }
        }

        public async Task<IActionResult> Update(ProjectPutDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            //anonim nesne
            var postObj = new
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                DepartmentId = dto.DepartmentId,
                ServiceId = dto.ServiceId,
            };

            var response = await _httpApiService.PutData<ResponseBody<ProjectItem>>("/project", JsonSerializer.Serialize(postObj), token.Token);

            //ya da response.statuscode == 201
            if (response.StatusCode.ToString().StartsWith("2"))
            {
                return Json(new { IsSuccess = true, Message = "Başarıyla Güncellendi" });

            }
            else
            {
                return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
            }





        }

    }
}
