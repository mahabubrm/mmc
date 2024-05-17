using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.Models.ViewModels
{
    public class RoleWisePermissionViewModel
    {
        public int RoleId { set; get; }
        public string ScreenCode { set; get; }
        public string ScreenName { set; get; }
        public bool IsCreate { set; get; }
        public bool IsRead { set; get; }
        public bool IsUpdate { set; get; }
        public bool IsDelete { set; get; }
        public string AccessRightCode { set; get; }

    }
}
