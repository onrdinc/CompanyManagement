using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ToDo.MvcUI.Areas.Admin.Extensions;
using ToDo.MvcUI.Areas.Admin.Models;

namespace ToDo.MvcUI.Areas.User.ViewComponents
{
    public class UserSideBarViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            
            var user = HttpContext.Session.GetObject<UserItem>("ActiveUser");

            return View(user);
        }
    }
}
