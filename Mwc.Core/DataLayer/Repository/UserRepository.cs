using Mwc.Core.DataLayer.Interface;
using Mwc.Core.Models;
using Mwc.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Mwc.Core.DataLayer.Repository
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUser, IDisposable
    {
        public MWCEntities context
        {
            get
            {
                return _db as MWCEntities;
            }
        }

        public UserRepository() : base(new MWCEntities())
        {

        }

        public void Dispose()
        {
            _db.Dispose();
        }                            
        
        

        public ApplicationUser GetByName(string UserName)
        {
            return context.ApplicationUsers.Where(o => o.UserName == UserName).FirstOrDefault();
        }

        public ReturnMessage SuperAdminLogin(UserLogin login, out ApplicationUser user)
        {
            user = new ApplicationUser();
            ReturnMessage message;
            message = ReturnMessage.SetSuccessMessage("Valid User");
            try
            {
                string saLogin = context.Database.SqlQuery<string>("SELECT name FROM sys.sql_logins where name = '"+login.UserName+ "' and pwdcompare('" + login.Password + "',password_hash) = 1 and is_disabled=0").FirstOrDefault();
                if (saLogin == null)
                {
                    message = ReturnMessage.SetErrorMessage("Invalid username or password");
                }
                else
                {
                    user = new ApplicationUser();
                    user.UserName = "sa";
                    user.RoleId = 1;
                    user.UserFullName = "Super Admin";
                }


                //else
                //{
                //    if (!PasswordHash.ValidatePassword(login.Password, user.Password))
                //    {
                //        message = ReturnMessage.SetErrorMessage("Invalid username or password");
                //    }
                //    else
                //    {
                //        if (!user.IsActive)
                //        {
                //            message = ReturnMessage.SetErrorMessage("Account is in-active");
                //        }
                //    }

                //}

            }
            catch (Exception ex)
            {
                message = ReturnMessage.SetErrorMessage();
            }

            return message;
        }

        public ApplicationUser GetByEmail(string emailId)
        {
            return context.ApplicationUsers.Where(o => o.Email == emailId).FirstOrDefault();
        }
    }
}
