using Mwc.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mwc.Web.Models
{
    public class BillPaymentModel
    {        
        public HttpPostedFileBase Image { get; set; }
        public string ImageData { get; set; }        
    }
}