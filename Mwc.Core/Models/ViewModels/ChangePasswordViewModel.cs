using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string UserName { set; get; }
        public string CurrentPassword { set; get; }
        public string NewPassword { set; get; }
        public string ConfirmNewPassword {  set; get; }
    }
}
