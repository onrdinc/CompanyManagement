using Microsoft.AspNetCore.Mvc;
using ToDo.MvcUI.Areas.Admin.Models.Dtos;
using ToDo.MvcUI.Areas.Admin.Models;
using ToDo.MvcUI.Areas.Admin.HttpApiServices;
using ToDo.MvcUI.Areas.Admin.Extensions;

namespace ToDo.MvcUI.Areas.User.Controllers
{
    [Area("User")]
    public class AuthenticationController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public AuthenticationController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto dto)
        {
            var response =
              await _httpApiService.GetData<ResponseBody<UserItem>>($"/User/logIn?nickname={dto.UserName}&password={dto.Password}");

            if (response.ErrorMessages == null || response.ErrorMessages.Count == 0)
            {
                HttpContext.Session.SetObject("ActiveUser", response.Data);
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
            return RedirectToAction("Index", "User");
        }
    }

   

}
