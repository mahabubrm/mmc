using Mwc.Web.Controllers;
using Mwc.Core.BusinessLayer.Interface;
using Mwc.Core.BusinessLayer.Manager;
using Mwc.Core.Models;
using Mwc.Core.Models.Common;
using Mwc.Core.Models.ViewModels;
using Mwc.Core.UtilityClassLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Mwc.Web.Areas.Admin.Controllers
{
    public class BackOfficeController : BaseController
    {        
        private IUserManager _userManager;
        

        public BackOfficeController()
        {            
            _userManager = new UserManager();            
        }
        public ActionResult Index()
        {
            return View();
        }
                
        

    }
}