using Mwc.Core.BusinessLayer.Interface;
using Mwc.Core.BusinessLayer.Manager;
using Mwc.Core.Models.Common;
using Mwc.Core.Models.ViewModels;
using Mwc.Web.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Mwc.Web.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        private IRoleWiseScreenPermissionManager _roleManager;
        public MenuController()
        {
            _roleManager = new RoleWiseScreenPermissionManager();
        }

        public virtual PartialViewResult Menu()
        {
            IEnumerable<MenuViewModel> Menu = null;
            var sessionUser = Session[AppSetting.Session] as AppSession;
            if (Session["_Menu"] != null)
            {
                Menu = (IEnumerable<MenuViewModel>)Session["_Menu"];
            }
            else
            {
                Menu = _roleManager.GetMenuByUserRole(sessionUser.RoleId);
                Session["_Menu"] = Menu;
            }
            return PartialView("_Menu", Menu);
        }
    }
}