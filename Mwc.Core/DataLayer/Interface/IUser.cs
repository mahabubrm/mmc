using Mwc.Core.Models;
using Mwc.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.DataLayer.Interface
{
    public interface IUser:IBaseRepository<ApplicationUser>
    {        
        //ReturnMessage ValidateUser(UserLogin login, out ApplicationUser user);

        ReturnMessage SuperAdminLogin(UserLogin login, out ApplicationUser user);
        ApplicationUser GetByName(string UserName);
        ApplicationUser GetByEmail(string emailId);
    }
}
