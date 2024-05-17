using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bcsgea.Web.Models
{
    public class ProfilePicModel
    {
        public string Name { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string ImageData { get; set; }
        public int ProfileId { set; get; }
    }
}