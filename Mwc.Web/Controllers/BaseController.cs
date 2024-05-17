using Mwc.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mwc.Web.Controllers
{
    public class BaseController : Controller
    {
        public AppSession AppSession;
        public ReturnMessage returnMessage;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Session[AppSetting.Session] != null)
            {
                AppSession = CurrentSession.GetCurrentSession();
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
            ViewBag.Session = AppSession;
            base.OnActionExecuting(filterContext);
        }
    }
}