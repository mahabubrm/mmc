using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.Models.ViewModels
{
    public class HomePageContentViewModel
    {
        public IEnumerable<Website_Notice> Notices {set;get;}
        public IEnumerable<Website_Notice> Minutes { set; get; }
        public IEnumerable<Website_Notice> Marquee { set; get; }
        public IEnumerable<WebSiteBanner> Banners { set; get; }
        public IEnumerable<PictureGalleryItem> PictureGallery { set; get; }
    }
}
