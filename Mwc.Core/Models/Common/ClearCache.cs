using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Mwc.Core.Models.Common
{
    public class ClearCache : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();
        }
    }

    public class JsonExtension : JsonResult
    {
        public JsonExtension(object objData)
        {
            Data = objData;
            ContentType = "application/json charset=utf-8";
            ContentEncoding = Encoding.UTF8;
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            MaxJsonLength = int.MaxValue;
        }
    }
}
