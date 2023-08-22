using Microsoft.AspNetCore.Mvc;
using ToDo.MvcUI.Areas.Admin.Extensions;
using ToDo.MvcUI.Areas.Admin.HttpApiServices;
using ToDo.MvcUI.Areas.Admin.Models;
using ToDo.MvcUI.Areas.Admin.ViewModels;
using ToDo.MvcUI.Areas.User.Filters;
using ToDo.MvcUI.Areas.User.ViewModels;

namespace ToDo.MvcUI.Areas.User.Controllers
{
    [Area("User")]
    [SessionAspect]
    public class MyProfileController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpApiService _httpApiService;
        public MyProfileController(IWebHostEnvironment webHostEnvironment, IHttpApiService httpApiService)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpApiService = httpApiService;
        }
        [HttpGet]

        public async Task<IActionResult> Index(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            var userResponse = 
                await _httpApiService.GetData<ResponseBody<UserItem>>($"/user/{id}", token.Token);
            return View(userResponse.Data);
        }
    }
}
