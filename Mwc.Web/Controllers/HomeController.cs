using Mwc.Core.BusinessLayer.Interface;
using Mwc.Core.BusinessLayer.Manager;
using Mwc.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mwc.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserManager _userManager;        
        private IWebsiteNoticeManager _noticeManager;        
        private IPictureGalleryManager _pictureGalleryManager;
        private IPictureGalleryItemManager _pictureGalleryItemsManager;        
        private IWebSiteBannerManager _bannerManager;
        

        public HomeController()
        {
            _userManager = new UserManager();            
            _noticeManager = new WebsiteNoticeManager();            
            _pictureGalleryManager = new PictureGalleryManager();
            _pictureGalleryItemsManager = new PictureGalleryItemManager();            
            _bannerManager = new WebSiteBannerManager();            
        }
        public ActionResult Index()
        {
            HomePageContentViewModel indexModel = new HomePageContentViewModel();
            indexModel.Notices = _noticeManager.GetAll().Where(o => o.NoticeType == "Notice").OrderByDescending(o => o.NoticeId).ToList();
            indexModel.Minutes = _noticeManager.GetAll().Where(o => o.NoticeType == "Minutes").OrderByDescending(o => o.NoticeId).ToList();
            indexModel.Banners = _bannerManager.GetAll().Where(o => o.IsDisplay == true).OrderBy(i => i.DisplaySL).ToList();
            indexModel.PictureGallery = _pictureGalleryItemsManager.GetAll().OrderByDescending(o => o.PicId).Take(10);
            ViewBag.Marquee = _noticeManager.GetAll().Where(o => o.IsShowScrollBar == true).OrderByDescending(o => o.NoticeId).ToList();
            return View(indexModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult ReadNotice(int noticeId)
        {            
            var notice = _noticeManager.GetById(noticeId);
            return View(notice);
        }

        public ActionResult ExecutiveCommittee()
        {
            return View();
        }

        public ActionResult ReadElectioNotice()
        {
            return View();
        }

        public FileResult DownloadFile()
        {
            return File("/Attachments/Election/NominationForm_2024.pdf", "application/pdf");
        }

        public ActionResult Admission()
        {
            return View();
        }

        public ActionResult GoverningBody()
        {
            return View();
        }
        public ActionResult Teachers()
        {
            return View();
        }

        public ActionResult Routine()
        {
            return View();
        }

    }
}