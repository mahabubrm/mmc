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
    public interface IRoleWiseScreenPermissionManager:IManager<RoleWiseScreenPermission>
    {
        ReturnMessage UpdateRoleWisePermission(List<RoleWiseScreenPermission> roleWiseScreens);
        IEnumerable<RoleWisePermissionViewModel> GetRoleWisePermission(int roleId, string parentScreenCode);
        IEnumerable<MenuViewModel> GetMenuByUserRole(int roleId);
    }
}
