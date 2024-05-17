using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mwc.Core.Models.Common
{
    public class CheckSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = CurrentSession.GetCurrentSession();
            if (session != null)
            {
                string redirectUrl = string.Format("~/Default/Index");
                filterContext.Result = new RedirectResult(redirectUrl);
            }
            else
            {
                string redirectUrl = string.Format("~/Login/Index");
                filterContext.Result = new RedirectResult(redirectUrl);
            }
        }
    }
}
