using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDo.MvcUI.Areas.Admin.Filters
{
    public class LogAspect : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //bu metod bu classın attribute olarak uygulandığı action metod çalışmaya başlar başlamaz otomatik olarak tetiklenecek

        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
        //bu metod bu classın attribute olarak uygulandığı action metod sonuç döndürmeden önce otomatik olarak tetiklenecek

        }
    }
}
