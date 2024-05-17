using Mwc.Core.Models;
using Mwc.Core.Models.Common;
using Mwc.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.BusinessLayer.Interface
{
    public interface IUserManager:IManager<ApplicationUser>
    {
        ApplicationUser GetByName(string UserName);
        ReturnMessage ValidateUser(UserLogin login, out ApplicationUser user);
        ReturnMessage ValidateBackOfficeUser(UserLogin login, out ApplicationUser user);
        ApplicationUser GetByEmail(string emailId);
        ReturnMessage SuperAdminValidate(UserLogin login, out ApplicationUser user);
        ReturnMessage ChangePassword(string password);        
    }
}
