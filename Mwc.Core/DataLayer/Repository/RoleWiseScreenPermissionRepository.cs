using Mwc.Core.DataLayer.Interface;
using Mwc.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.DataLayer.Repository
{
    public class RoleWiseScreenPermissionRepository : BaseRepository<RoleWiseScreenPermission>, IRoleWiseScreenPermission, IDisposable
    {
        public MWCEntities context
        {
            get
            {
                return _db as MWCEntities;
            }
        }

        public RoleWiseScreenPermissionRepository() : base(new MWCEntities())
        {

        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public RoleWiseScreenPermission GetRoleWiseScreenPermission(int roleId, string screenCode)
        {
            return context.RoleWiseScreenPermissions.Where(o => o.RoleId == roleId & o.ScreenCode == screenCode).FirstOrDefault();
        }
    }
}
