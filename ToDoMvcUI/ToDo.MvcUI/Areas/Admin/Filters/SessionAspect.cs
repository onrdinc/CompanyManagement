using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDo.MvcUI.Areas.Admin.Filters
{
    public class SessionAspect : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //bu metod bu classın attribute olarak uygulandığı action metod çalışmaya başladığında otomatik olarak tetiklenecek
            var sessionJson = context.HttpContext.Session.GetString("ActiveAdminUser");
            if (string.IsNullOrEmpty(sessionJson))
            {
                //login sayfasına yönlendirecek 
                //return new RedirectToAction("LogIn", "Authentication");
                context.Result = new RedirectToActionResult("LogIn", "Authentication", null);
            }
        }
    }
}
