using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.MvcUI.Areas.User.Filters
{
    public class SessionAspect : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //bu metod bu classın attribute olarak uygulandığı action metod çalışmaya başladığında otomatik olarak tetiklenecek
            var sessionJson = context.HttpContext.Session.GetString("ActiveUser");
            if (string.IsNullOrEmpty(sessionJson))
            {
                //login sayfasına yönlendirecek 
                //return new RedirectToAction("LogIn", "Authentication");
                context.Result = new RedirectResult("/User/Authentication/LogIn");
            }
        }
    }
}
