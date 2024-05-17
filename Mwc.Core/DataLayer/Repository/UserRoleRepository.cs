using Mwc.Core.DataLayer.Interface;
using Mwc.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mwc.Core.DataLayer.Repository
{
    public class UserRoleRepository : BaseRepository<UserRoleList>, IUserRole, IDisposable
    {
        public MWCEntities context
        {
            get
            {
                return _db as MWCEntities;
            }
        }

        public UserRoleRepository() : base(new MWCEntities())
        {

        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<SelectListItem> GetAllRoleName()
        {            
            return from p in context.UserRoleLists
                   select new SelectListItem
                   {
                       Text = p.RoleName,
                       Value = p.RoleID.ToString()
                   };
        }
    }
}
