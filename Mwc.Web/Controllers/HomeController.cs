using Mwc.Core.BusinessLayer.Interface;
using Mwc.Core.BusinessLayer.Manager;
using Mwc.Core.Models.Common;
using Mwc.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

        
        public FileResult DownloadFile(string fileName)
        {
            var FileVirtualPath = "~/Attachments/Forms/" + fileName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
            //return File("/Attachments/Forms/" + fileName, "application/force-download");
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

        public ActionResult Poriciti()
        {
            return View();
        }

        public ActionResult PrincipalSpeech()
        {
            return View();
        }

        public ActionResult ChairmanSpeech()
        {
            return View();
        }

        public ActionResult AdvisorSpeech()
        {
            return View();
        }

        public ActionResult HscAdmission()
        {
            return View();
        }

        public ActionResult PassAdmission()
        {
            return View();
        }

        public ActionResult HonorsAdmission()
        {
            return View();
        }

        public ActionResult ProfessionalAdmission()
        {
            return View();
        }

        public ActionResult MastersAdmission()
        {
            return View();
        }

        public ActionResult HscDepartment()
        {
            return View();
        }

        public ActionResult PassDepartment()
        {
            return View();
        }

        public ActionResult HonorsDepartment()
        {
            return View();
        }

        public ActionResult ProfessionalDepartment()
        {
            return View();
        }

        public ActionResult MastersDepartment()
        {
            return View();
        }

        public ActionResult CollegeOffice()
        {
            return View();
        }

        public ActionResult SyllabusInfo()
        {
            return View();
        }

        public ActionResult SyllabusStudyPlan()
        {
            return View();
        }

        public ActionResult ExamPlan()
        {
            return View();
        }

        public ActionResult ExamResult()
        {
            return View();
        }

        public ActionResult Acheavements()
        {
            var acheivements = _pictureGalleryItemsManager.GetAll().Where(o => o.PictureGallery.GalleryDescription.Trim() == "1122").OrderByDescending(o=>o.PicId).ToList();
            return View(acheivements);
        }

        public ActionResult AllForms()
        {
            var forms = _noticeManager.GetAll().Where(o => o.NoticeType.ToString() == AppConstant.NoticType.Forms.ToString()).ToList();
            return View(forms);
        }



    }
}