using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ToDo.MvcUI.Areas.Admin.Extensions;
using ToDo.MvcUI.Areas.Admin.Filters;
using ToDo.MvcUI.Areas.Admin.HttpApiServices;
using ToDo.MvcUI.Areas.Admin.Models;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.Contact;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.DepartmentDtos;

namespace ToDo.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public ContactController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [SessionAspect]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.GetData<ResponseBody<List<ContactItem>>>("/contact", token.Token);
            return View(response.Data);
        }

        [SessionAspect]
        [HttpPost]
        public async Task<IActionResult> GetContact(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response =
              await _httpApiService.GetData<ResponseBody<ContactItem>>($"/contact/{id}", token.Token);

            return Json(new { 
                NameSurname = response.Data.NameSurname,
                Email = response.Data.Email,
                Subject = response.Data.Subject,
                Phone = response.Data.Phone });
        }

        [SessionAspect]
        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/contact/{id}", token.Token);

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }

        public async Task<IActionResult> Save(NewContactDto dto)
        {

            //anonim nesne
            var postObj = new
            {
                Email = dto.Email,
                Phone = dto.Phone,
                Subject = dto.Subject,
                NameSurname = dto.NameSurname,
            };

            var response = await _httpApiService.PostData<ResponseBody<ContactItem>>("/contact", JsonSerializer.Serialize(postObj));

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


    }
}
