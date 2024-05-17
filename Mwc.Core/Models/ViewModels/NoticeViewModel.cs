using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.Models.ViewModels
{
    public class NoticeViewModel
    {
        public int NoticeId { set; get; }
        public DateTime NoticeDate { set; get; }
        public string NoticeTitle { set; get; }
        public int TotalView { set; get; }
        public string NoticeType { set; get; }
    }
}
