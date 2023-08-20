using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Text.Json;
using ToDo.MvcUI.Areas.Admin.Extensions;
using ToDo.MvcUI.Areas.Admin.Models;

namespace ToDo.MvcUI.Areas.Admin.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            //var sessionJsonData = HttpContext.Session.GetString("ActiveAdminUser");
            //var adminUser = JsonSerializer.Deserialize<AdminUserItem>(sessionJsonData);

            //return View(adminUser);
            var adminUser = HttpContext.Session.GetObject<AdminUserItem>("ActiveAdminUser");

            return View(adminUser);
        }
    }
}
