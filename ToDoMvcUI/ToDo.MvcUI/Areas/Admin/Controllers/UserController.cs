using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Xml.Linq;
using ToDo.MvcUI.Areas.Admin.Extensions;
using ToDo.MvcUI.Areas.Admin.Filters;
using ToDo.MvcUI.Areas.Admin.HttpApiServices;
using ToDo.MvcUI.Areas.Admin.Models;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.UserDtos;
using ToDo.MvcUI.Areas.Admin.ViewModels;

namespace ToDo.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpApiService _httpApiService;
        public UserController(IWebHostEnvironment webHostEnvironment, IHttpApiService httpApiService)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var userResponse = await _httpApiService.GetData<ResponseBody<List<UserItem>>>("/user",token.Token);
            var departmentResponse = await _httpApiService.GetData<ResponseBody<List<DepartmentItem>>>("/department",token.Token);
            UserViewModel vm = new UserViewModel();
            vm.Users = userResponse.Data;
            vm.Departments = departmentResponse.Data;
            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> GetUser(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response =
              await _httpApiService.GetData<ResponseBody<UserItem>>($"/user/{id}",token.Token);

            return Json(new { Name = response.Data.Name, Surname = response.Data.Surname, Email = response.Data.Email,Nickname = response.Data.Nickname,Password = response.Data.Password,DepartmentName = response.Data.DepartmentName,DepartmentId = response.Data.DepartmentId, PicturePath = response.Data.PicturePath });
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewUserDto dto, IFormFile userPhoto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            if (userPhoto != null)
            {

                if (!userPhoto.ContentType.StartsWith("image/"))

                    return Json(new { IsSuccess = false, Message = "Personel için sadece resim dosyası seçilmelidir." });

                //if(userPhoto.Length > 500*1024)
                //    return Json(new { IsSuccess = false, Message = "Personel için sadece resim dosyası maximum 500 KB olabilir." });

                //uzantısını veriyor

                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(userPhoto.FileName)}";

                var picturePath = $@"/images/{randomFileName}";

                //dosya yolu
                var upload = $@"{_webHostEnvironment.ContentRootPath}/wwwroot{picturePath}";


                using (var fs = new FileStream(upload, FileMode.Create))
                {
                    userPhoto.CopyTo(fs);

                }

                //anonim nesne
                var postObj = new
                {
                    Name = dto.Name,
                    Surname = dto.Surname,
                    Email = dto.Email,
                    Nickname = dto.Nickname,
                    DepartmentId = dto.DepartmentId,
                    Password = dto.Password,
                    PicturePath = picturePath,
                    PictureBase64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(upload)),
                };

                var response = await _httpApiService.PostData<ResponseBody<UserItem>>("/user", JsonSerializer.Serialize(postObj),token.Token);

                //ya da response.statuscode == 201
                if (response.StatusCode.ToString().StartsWith("2"))
                {
                    return Json(new { IsSuccess = true, Message = "Başarıyla Kaydedildi",UserPicture = response.Data.UserPicture,PicturePath = response.Data.PicturePath,Id = response.Data.Id });

                }
                else
                {
                    return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
                }

             

            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Personel için resim seçilmelidir." });

            }


        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/user/{id}",token.Token);

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }

        public async Task<IActionResult> Update(UserPutDto dto,IFormFile userPhoto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            if (userPhoto != null)
            {

                if (!userPhoto.ContentType.StartsWith("image/"))

                    return Json(new { IsSuccess = false, Message = "Personel için sadece resim dosyası seçilmelidir." });

                //if(userPhoto.Length > 500*1024)
                //    return Json(new { IsSuccess = false, Message = "Personel için sadece resim dosyası maximum 500 KB olabilir." });

                //uzantısını veriyor

                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(userPhoto.FileName)}";

                var picturePath = $@"/images/{randomFileName}";

                //dosya yolu
                var upload = $@"{_webHostEnvironment.ContentRootPath}/wwwroot{picturePath}";


                using (var fs = new FileStream(upload, FileMode.Create))
                {
                    userPhoto.CopyTo(fs);

                }

                //anonim nesne
                var postObj = new
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Surname = dto.Surname,
                    Email = dto.Email,
                    Nickname = dto.Nickname,
                    DepartmentId = dto.DepartmentId,
                    Password = dto.Password,
                    PicturePath = picturePath,
                    PictureBase64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(upload)),
                };

                var response = await _httpApiService.PutData<ResponseBody<UserItem>>("/user", JsonSerializer.Serialize(postObj), token.Token);

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
            else
            {
                return Json(new { IsSuccess = false, Message = "Personel için resim seçilmelidir." });

            }
        }

    }
}
