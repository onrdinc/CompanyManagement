using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ToDo.MvcUI.Areas.Admin.Extensions;
using ToDo.MvcUI.Areas.Admin.Filters;
using ToDo.MvcUI.Areas.Admin.HttpApiServices;
using ToDo.MvcUI.Areas.Admin.Models;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.ProjectParticipant;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.WageDtos;
using ToDo.MvcUI.Areas.Admin.ViewModels;

namespace ToDo.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class WageController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public WageController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var wageResponse = await _httpApiService.GetData<ResponseBody<List<WageItem>>>("/wage", token.Token);
            var userResponse = await _httpApiService.GetData<ResponseBody<List<UserItem>>>("/user", token.Token);

            WageViewModel vm = new WageViewModel();
            vm.Users = userResponse.Data;
            vm.Wages = wageResponse.Data;

            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> GetWage(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response =
              await _httpApiService.GetData<ResponseBody<WageItem>>($"/wage/{id}", token.Token);

            return Json(new
            {
                Amount = response.Data.Amount,
                UserId = response.Data.User.Id,
                PicturePath = response.Data.User.PicturePath,
                UserNameSurname = response.Data.User.Name + " " + response.Data.User.Surname,
            });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/wage/{id}", token.Token);

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }

        public async Task<IActionResult> Save(NewWageDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            //anonim nesne
            var postObj = new
            {
                Amount = dto.Amount,
                UserId = dto.UserId,
               
            };

            var response = await _httpApiService.PostData<ResponseBody<WageItem>>("/wage", JsonSerializer.Serialize(postObj), token.Token);

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

        public async Task<IActionResult> Update(WagePutDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            //anonim nesne
            var postObj = new
            {
                Id = dto.Id,
                Amount = dto.Amount,
                UserId = dto.UserId,
            };

            var response = await _httpApiService.PutData<ResponseBody<WageItem>>("/wage", JsonSerializer.Serialize(postObj), token.Token);

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
