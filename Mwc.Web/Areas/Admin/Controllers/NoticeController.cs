using Mwc.Web.Controllers;
using Mwc.Core.BusinessLayer.Interface;
using Mwc.Core.BusinessLayer.Manager;
using Mwc.Core.Models;
using Mwc.Core.Models.Common;
using Mwc.Core.Models.ViewModels;
using Mwc.Core.UtilityClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mwc.Web.Areas.Admin.Controllers
{
    public class NoticeController : BaseController
    {
        public IWebsiteNoticeManager _noticeManager;        
        public NoticeController()
        {
            _noticeManager = new WebsiteNoticeManager();            
        }

        public ActionResult NoticeBoards()
        {
            var message = new ReturnMessage();
            if (TempData["Message"] != null)
            {
                message = TempData["Message"] as ReturnMessage;
            }
            ViewBag.Message = message;
            var notices = _noticeManager.GetAllNotice("Notice");
            return View(notices);
        }

        public ActionResult AddNotice()
        {
            var message = new ReturnMessage();
            if (TempData["Message"] != null)
            {
                message = TempData["Message"] as ReturnMessage;
            }
            ViewBag.Message = message;
            //ViewBag.Depts = _deptManager.GetAll().Select(o => new SelectListItem { Text = o.DepartmentName, Value = o.DeptId.ToString() }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddNotice(Website_Notice model, HttpPostedFileBase attchment)
        {
            var path = string.Empty;
            string noticeName = string.Empty;
            var fileName = new SqlQryManager().GetTransactionNo();
            if (attchment != null)
            {
                string filename = Path.GetFileName(attchment.FileName);
                //string fileExt = Path.GetExtension(filename);
                noticeName = fileName + "_" + filename;
                path = Path.Combine(Server.MapPath("~/Attachments/WebsiteNoticeDocuments"), noticeName);

            }
            model.IsShowScrollBar = (model.IsShowScrollBar == null) ? false : true;
            model.IsActive = true;
            model.NoticeAttachment = noticeName;
            model.NoticeDate = DateTime.Now;
            model.NoticeType = "Notice";
            var message = _noticeManager.Add(model);
            TempData["Message"] = message;
            if (message.MessageType == MessageTypes.Success)
            {
                if (attchment != null)
                {
                    attchment.SaveAs(path);
                }
            }
            return RedirectToAction("AddNotice");
        }

        public ActionResult DeleteNotice(int noticeId)
        {
            var item = _noticeManager.GetById(noticeId);
            var message = _noticeManager.Remove(item);
            TempData["Message"] = message;
            return RedirectToAction("NoticeBoards","Notice");
        }

        public ActionResult EditNotice(int noticeId)
        {
            //ViewBag.Depts = _deptManager.GetAll().Select(o => new SelectListItem { Text = o.DepartmentName, Value = o.DeptId.ToString() }).ToList();
            var item = _noticeManager.GetById(noticeId);
            return View(item);
        }

        [HttpPost]
        public ActionResult EditNotice(Website_Notice model, HttpPostedFileBase attchment)
        {
            var path = string.Empty;
            string noticeName = string.Empty;
            var fileName = new SqlQryManager().GetTransactionNo();
            if (attchment != null)
            {
                string filename = Path.GetFileName(attchment.FileName);
                string fileExt = Path.GetExtension(filename);
                noticeName = fileName + "_" + filename + fileExt;
                path = Path.Combine(Server.MapPath("~/Attachments/WebsiteNoticeDocuments"), noticeName);

            }
            model.IsShowScrollBar = (model.IsShowScrollBar == null) ? false : true;
            model.IsActive = true;
            model.NoticeAttachment = (attchment == null) ? model.NoticeAttachment : noticeName;
            model.NoticeDate = DateTime.Now;
            model.NoticeType = "Notice";
            var message = _noticeManager.Update(model);
            TempData["Message"] = message;
            if (message.MessageType == MessageTypes.Success)
            {
                if (attchment != null)
                {
                    attchment.SaveAs(path);
                }
            }
            return RedirectToAction("NoticeBoards");
        }



        //-------------------------Minutes-----------------------------//


        public ActionResult Minutes()
        {
            var message = new ReturnMessage();
            if (TempData["Message"] != null)
            {
                message = TempData["Message"] as ReturnMessage;
            }
            ViewBag.Message = message;
            var notices = _noticeManager.GetAll().Where(o=>o.NoticeType=="Minutes").OrderByDescending(o => o.NoticeId).ToList();
            return View(notices);
        }

        public ActionResult AddMinutes()
        {
            var message = new ReturnMessage();
            if (TempData["Message"] != null)
            {
                message = TempData["Message"] as ReturnMessage;
            }
            ViewBag.Message = message;
            //ViewBag.Depts = _deptManager.GetAll().Select(o => new SelectListItem { Text = o.DepartmentName, Value = o.DeptId.ToString() }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddMinutes(Website_Notice model, HttpPostedFileBase attchment)
        {
            var path = string.Empty;
            string noticeName = string.Empty;
            var fileName = new SqlQryManager().GetTransactionNo();
            if (attchment != null)
            {
                string filename = Path.GetFileName(attchment.FileName);
                //string fileExt = Path.GetExtension(filename);
                noticeName = fileName + "_" + filename;
                path = Path.Combine(Server.MapPath("~/Attachments/WebsiteNoticeDocuments"), noticeName);

            }
            model.IsShowScrollBar = false;
            model.IsActive = true;
            model.NoticeAttachment = noticeName;
            model.NoticeDate = DateTime.Now;
            model.NoticeType = "Minutes";
            var message = _noticeManager.Add(model);
            TempData["Message"] = message;
            if (message.MessageType == MessageTypes.Success)
            {
                if (attchment != null)
                {
                    attchment.SaveAs(path);
                }
            }
            return RedirectToAction("AddNotice");
        }

        public ActionResult DeleteMinutes(int noticeId)
        {
            var item = _noticeManager.GetById(noticeId);
            var message = _noticeManager.Remove(item);
            TempData["Message"] = message;
            return RedirectToAction("Minutes","Notice");
        }

        public ActionResult EditMinutes(int noticeId)
        {
            //ViewBag.Depts = _deptManager.GetAll().Select(o => new SelectListItem { Text = o.DepartmentName, Value = o.DeptId.ToString() }).ToList();
            var item = _noticeManager.GetById(noticeId);
            return View(item);
        }

        [HttpPost]
        public ActionResult EditMinutes(Website_Notice model, HttpPostedFileBase attchment)
        {
            var path = string.Empty;
            string noticeName = string.Empty;
            var fileName = new SqlQryManager().GetTransactionNo();
            if (attchment != null)
            {
                string filename = Path.GetFileName(attchment.FileName);
                string fileExt = Path.GetExtension(filename);
                noticeName = fileName + "_" + filename + fileExt;
                path = Path.Combine(Server.MapPath("~/Attachments/WebsiteNoticeDocuments"), noticeName);

            }
            model.IsShowScrollBar = (model.IsShowScrollBar == null) ? false : true;
            model.IsActive = true;
            model.NoticeAttachment = (attchment == null) ? model.NoticeAttachment : noticeName;
            model.NoticeDate = DateTime.Now;
            model.NoticeType = "Minutes";
            var message = _noticeManager.Update(model);
            TempData["Message"] = message;
            if (message.MessageType == MessageTypes.Success)
            {
                if (attchment != null)
                {
                    attchment.SaveAs(path);
                }
            }
            return RedirectToAction("NoticeBoards");
        }
    }
}