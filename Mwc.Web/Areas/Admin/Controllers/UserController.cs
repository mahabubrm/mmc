using Mwc.Web.Controllers;
using Mwc.Core.BusinessLayer.Interface;
using Mwc.Core.BusinessLayer.Manager;
using Mwc.Core.Models;
using Mwc.Core.Models.Common;
using Mwc.Core.Models.ViewModels;
using Mwc.Core.UtilityClassLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mwc.Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private IUserManager _userManager;
        private IUserRoleManager _userRoleManager;
        //private ISendEmailManager _sendEmailManager;
        public UserController()
        {
            _userManager = new UserManager();
            _userRoleManager = new UserRoleManager();
            //_sendEmailManager = new SendEmailManager();
        }

        public ActionResult Users()
        {
            var message = new ReturnMessage();
            if (TempData["Message"] != null)
            {
                message = TempData["Message"] as ReturnMessage;
            }
            ViewBag.Message = message;
            var model = _userManager.GetAll();
            return View(model);
        }
        public ActionResult CreateUser()
        {
            ViewBag.Roles = _userRoleManager.GetAllRoleName();
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(ApplicationUser user)
        {
            var message = _userManager.Add(user);
            //if (message.MessageType.ToString() == "Success")
            //{
            //    EmailParameter emailParameter = new EmailParameter();
            //    emailParameter.WebAddress = ConfigurationManager.AppSettings["ErpURL"].ToString();
            //    emailParameter.UserName = user.UserName;
            //    emailParameter.Password = DataEncryptionUtilities.GenerateDecryptedString(user.Password);
            //    emailParameter.ClientMailAddress = user.Email;
            //    emailParameter.MailSubject = ConfigurationManager.AppSettings["CreateUserSubject"].ToString();
            //    _sendEmailManager.SendEmailToUser(emailParameter);
            //}
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateUser(int userId)
        {
            var model = _userManager.GetById(userId);
            ViewBag.Roles = _userRoleManager.GetAllRoleName();
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateUser(ApplicationUser user)
        {
            var message = _userManager.Update(user);
            TempData["Message"] = message;
            return RedirectToAction("Users");
        }


        public JsonResult UserIsValid(string userName)
        {
            bool valid = false;
            var user = _userManager.GetByName(userName);
            if (user != null)
            {
                valid = true;
            }

            return Json(valid, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUser(int userId = 0)
        {
            var user = _userManager.GetById(userId);
            return View(user);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            var message = _userManager.ChangePassword(model.NewPassword);
            Session["Session"] = null;
            Session.RemoveAll();
            return RedirectToAction("Index", "BackOfficeLogin", new { Area = "Admin" });
        }

    }
}