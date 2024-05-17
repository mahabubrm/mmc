using Mwc.Core.Models;
using Mwc.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.BusinessLayer.Interface
{
    public interface IWebsiteNoticeManager:IManager<Website_Notice>
    {
        IEnumerable<NoticeViewModel> GetAllNotice(string nType);
    }
}
