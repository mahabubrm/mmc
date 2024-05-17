using Mwc.Core.BusinessLayer.Interface;
using Mwc.Core.BusinessLayer.Manager;
using Mwc.Core.Models;
using Mwc.Core.Models.Common;
using Mwc.Web.Controllers;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mwc.Web.Areas.Admin.Controllers
{
    public class GalleryController : BaseController
    {
        private IUserManager _userManager;
        private IPictureGalleryManager _pictureGalleryManager;
        private IPictureGalleryItemManager _pictureGalleryItemsManager;
        private IWebSiteBannerManager _bannerRepository;

        public GalleryController()
        {
            _userManager = new UserManager();
            _pictureGalleryManager = new PictureGalleryManager();
            _pictureGalleryItemsManager = new PictureGalleryItemManager();
            _bannerRepository = new WebSiteBannerManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PictureGalleryFolders()
        {
            var message = new ReturnMessage();
            if (TempData["Message"] != null)
            {
                message = TempData["Message"] as ReturnMessage;
            }
            ViewBag.Message = message;
            var galleries = _pictureGalleryManager.GetAll().Where(o => o.IsActive == true).ToList();
            return View(galleries);
        }

        public ActionResult CreateGallery()
        {
            var message = new ReturnMessage();
            if (TempData["Message"] != null)
            {
                message = TempData["Message"] as ReturnMessage;
            }
            ViewBag.Message = message;
            return View();
        }


        [HttpPost]
        public ActionResult CreateGallery(PictureGallery model)
        {
            model.IsActive = true;
            var message = _pictureGalleryManager.Add(model);
            TempData["Message"] = message;
            return RedirectToAction("CreateGallery");
        }

        public ActionResult UpdateGallery(int galleryId)
        {
            var gallery = _pictureGalleryManager.GetById(galleryId);
            return View(gallery);
        }

        [HttpPost]
        public ActionResult UpdateGallery(PictureGallery model)
        {
            var message = _pictureGalleryManager.Update(model);
            TempData["Message"] = message;
            return RedirectToAction("PictureGalleryFolders");
        }

        public ActionResult UploadPicture(int galleryId)
        {
            var message = new ReturnMessage();
            if (TempData["Message"] != null)
            {
                message = TempData["Message"] as ReturnMessage;
            }
            ViewBag.Message = message;
            var gallery = _pictureGalleryManager.GetById(galleryId);
            return View(gallery);
        }
        [HttpPost]
        public ActionResult UploadPicture(PictureGalleryItem model, HttpPostedFileBase StdPhoto)
        {
            var path = string.Empty;
            string imageName = string.Empty;
            if (StdPhoto != null)
            {
                string filename = Path.GetFileName(StdPhoto.FileName);
                string fileExt = Path.GetExtension(filename);
                imageName = DateTime.Now.Ticks + "_" + filename + fileExt;
                path = Path.Combine(Server.MapPath("~/Attachments/PictureGallery"), imageName);
            }

            model.IsActive = true;
            model.PictureName = imageName;
            var message = _pictureGalleryItemsManager.Add(model);
            TempData["Message"] = message;
            if (message.MessageType == MessageTypes.Success)
            {
                if (StdPhoto != null)
                {
                    StdPhoto.SaveAs(path);
                }
            }
            return RedirectToAction("UploadPicture", new { galleryId = model.GalleryId } );
        }

        public ActionResult Banner()
        {
            var message = new ReturnMessage();
            if (TempData["Message"] != null)
            {
                message = TempData["Message"] as ReturnMessage;
            }
            ViewBag.Message = message;
            var banners = _bannerRepository.GetAll();
            return View(banners);
        }

        public ActionResult AddBanner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBanner(WebSiteBanner model, HttpPostedFileBase bannerFile)
        {
            string imgPath = string.Empty;
            string fileName = string.Empty;

            if (bannerFile != null)
            {
                string filename = Path.GetFileName(bannerFile.FileName);
                //string fileExt = Path.GetExtension(filename);
                filename = DateTime.Now.Ticks + "_" + filename;
                imgPath = Path.Combine(Server.MapPath("~/Attachments/Slider"), filename);
                model.BannerImgName = filename;
            }
            model.IsDisplay = (model.IsDisplay == null) ? false : true;
            var message = _bannerRepository.Add(model);
            TempData["Message"] = message;
            if (message.MessageType == MessageTypes.Success)
            {
                if (bannerFile != null)
                {
                    bannerFile.SaveAs(imgPath);
                }
            }

            return RedirectToAction("Banner");
        }

        public ActionResult DeleteBannerImg(int bannerId)
        {
            var banner = _bannerRepository.GetById(bannerId);
            var message = _bannerRepository.Remove(banner);
            TempData["Message"] = message;
            return RedirectToAction("Banner");
        }

    }
}