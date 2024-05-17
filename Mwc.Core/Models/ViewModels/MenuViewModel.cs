using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.Models.ViewModels
{
    public class MenuViewModel
    {
        public string MenuCode { set; get; }
        public string MenuName { set; get; }
        public string MenuURL { set; get; }
        public string MenuParentID { set; get; }
        public bool IsRequiredForApproval { set; get; }
        public bool IsEmailNotificationSend { set; get; }
        public string MenuIcon { set; get; }
        public string ModuleId { set; get; }
    }
}
