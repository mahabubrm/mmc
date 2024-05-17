using Mwc.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mwc.Core.BusinessLayer.Interface
{
    public interface IUserRoleManager : IManager<UserRoleList>
    {
        IEnumerable<SelectListItem> GetAllRoleName();
    }
}
