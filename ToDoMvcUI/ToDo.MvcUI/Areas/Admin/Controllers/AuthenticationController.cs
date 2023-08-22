using Microsoft.AspNetCore.Mvc;
using ToDo.MvcUI.Areas.Admin.Extensions;
using ToDo.MvcUI.Areas.Admin.HttpApiServices;
using ToDo.MvcUI.Areas.Admin.Models;
using ToDo.MvcUI.Areas.Admin.Models.Dtos;

namespace ToDo.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AuthenticationController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public AuthenticationController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto dto)
        {
            var response =
              await _httpApiService.GetData<ResponseBody<AdminUserItem>>($"/Authentication/logIn?userName={dto.UserName}&password={dto.Password}");

            if (response.ErrorMessages == null || response.ErrorMessages.Count == 0)
            {
                HttpContext.Session.SetObject("ActiveAdminUser", response.Data);
                await GetTokenAndSetInSession();


                return Json(new { IsSuccess = true, Messages = "Kullanıcı Bulundu" });
            }
            else
            {
                //Anonim Nesne
                return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
            }
        }

        public async Task GetTokenAndSetInSession()
        {
            var response = await _httpApiService.GetData<ResponseBody<AccessTokenItem>>(@"/authentication/gettoken");

            HttpContext.Session.SetObject("AccessToken", response.Data);
        }

        public async Task<IActionResult> SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Admin");
        }
    }
}
