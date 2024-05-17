using Mwc.Core.BusinessLayer.Interface;
using Mwc.Core.BusinessLayer.Manager;
using Mwc.Core.Models;
using Mwc.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mwc.Web.Areas.Admin.Controllers
{
    public class BackOfficeLoginController : Controller
    {
        private IUserManager _userManager;
        
        public BackOfficeLoginController()
        {
            _userManager = new UserManager();            
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLogin login)
        {
            var user = new ApplicationUser();
            var message = _userManager.ValidateBackOfficeUser(login, out user);
            if (message.MessageType == MessageTypes.Success)
            {
                //Session["Session"] = user;
                return RedirectToAction("Index", "BackOffice", new { Areas = "Admin" });

            }

            ViewBag.Error = message.Message;
            return View();
        }

        public ActionResult LogOut()
        {
            Session["Session"] = null;
            Session.RemoveAll();
            return RedirectToAction("Index", "BackOfficeLogin", new { Areas = "Admin" });
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var user = _userManager.GetByName(userName);
                if (user != null)
                {                    
                    return PartialView("_responseMsg");
                }
                else
                {
                    ViewBag.Msg = "Sorry! user not found.";
                    return View();
                }
            }
            else
            {
                ViewBag.Msg = "Invalid Input.";
                return View();
            }

        }
    }
}