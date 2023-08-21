using Microsoft.AspNetCore.Mvc;
using ToDo.MvcUI.Areas.Admin.Extensions;
using ToDo.MvcUI.Areas.Admin.Filters;
using ToDo.MvcUI.Areas.Admin.HttpApiServices;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.DepartmentDtos;
using ToDo.MvcUI.Areas.Admin.Models;
using System.Text.Json;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.ServiceDtos;

namespace ToDo.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class ServiceController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpApiService _httpApiService;
        public ServiceController(IWebHostEnvironment webHostEnvironment, IHttpApiService httpApiService)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.GetData<ResponseBody<List<ServiceItem>>>("/service", token.Token);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> GetService(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response =
              await _httpApiService.GetData<ResponseBody<ServiceItem>>($"/service/{id}", token.Token);

            return Json(new { Name = response.Data.Name, Description = response.Data.Description });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/service/{id}", token.Token);

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewServiceDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            //anonim nesne
            var postObj = new
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            var response = await _httpApiService.PostData<ResponseBody<ServiceItem>>("/service", JsonSerializer.Serialize(postObj), token.Token);

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

        public async Task<IActionResult> Update(ServicePutDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            //anonim nesne
            var postObj = new
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description
            };

            var response = await _httpApiService.PutData<ResponseBody<ServiceItem>>("/service", JsonSerializer.Serialize(postObj), token.Token);

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
