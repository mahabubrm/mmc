using Mwc.Core.BusinessLayer.Interface;
using Mwc.Core.DataLayer.Repository;
using Mwc.Core.Models;
using Mwc.Core.Models.Common;
using Mwc.Core.Models.ViewModels;
using Mwc.Core.UtilityClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Mwc.Core.BusinessLayer.Manager
{
    public class UserManager : IUserManager
    {
        public UserRepository _userRepository;        
        public ReturnMessage _returnMessage;
        public bool _isSaveChanges;
        private AppSession _sessionUser = null;
        public UserManager()
        {
            _userRepository = new UserRepository();            
            _returnMessage = new ReturnMessage();            
            _sessionUser = HttpContext.Current.Session[AppSetting.Session] as AppSession;
        }
        public ReturnMessage Add(ApplicationUser entity)
        {
            var encPassword = DataEncryptionUtilities.GenerateEncryptedString(entity.Password);
            entity.Password = encPassword;
            entity.IsLockedOut = false;

            var sessionUser = HttpContext.Current.Session[AppSetting.Session] as AppSession;
            entity.EntryUserName = sessionUser.UserName;
            entity.SetDate = DateTime.Now;

            _isSaveChanges = _userRepository.Add(entity);
            if (_isSaveChanges)
            {
                _returnMessage = ReturnMessage.SetSuccessMessage();
            }
            else
            {
                _returnMessage = ReturnMessage.SetErrorMessage();
            }

            //var isUserExists = GetByName(entity.UserName);
            //var isEmailExists = GetByEmail(entity.Email);
            //if (isUserExists != null)
            //{
            //    if (isEmailExists != null)
            //    {
            //        _returnMessage = ReturnMessage.SetErrorMessage("User name & Email is Exists. Please try different");
            //    }
            //    else
            //    {
            //        _returnMessage = ReturnMessage.SetErrorMessage("User name is Exists");
            //    }

            //}
            //else
            //{
            //    if (isEmailExists != null)
            //    {
            //        _returnMessage = ReturnMessage.SetErrorMessage("Email is Exists. Please try different");
            //    }
            //    else
            //    {
            //        _isSaveChanges = _userRepository.Add(entity);
            //        if (_isSaveChanges)
            //        {
            //            _returnMessage = ReturnMessage.SetSuccessMessage();
            //        }
            //        else
            //        {
            //            _returnMessage = ReturnMessage.SetErrorMessage();
            //        }
            //    }
            //}

            return _returnMessage;
        }

        public ReturnMessage ChangePassword(string password)
        {
            var sessionUser = HttpContext.Current.Session[AppSetting.Session] as AppSession;
            var user = _userRepository.GetAll().Where(o => o.UserName.Trim() == sessionUser.UserName.Trim()).FirstOrDefault();
            var encPass= DataEncryptionUtilities.GenerateEncryptedString(password);
            user.Password = encPass;
            _isSaveChanges = _userRepository.Update(user);
            if (_isSaveChanges)
            {
                _returnMessage = ReturnMessage.SetUpdateSuccessMessage();
            }
            else
            {
                _returnMessage = ReturnMessage.SetErrorMessage();
            }
            return _returnMessage;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _userRepository.GetAll();
        }
        
        public ApplicationUser GetByEmail(string emailId)
        {
            return _userRepository.GetByEmail(emailId);
        }

        public ApplicationUser GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public ApplicationUser GetByName(string UserName)
        {
            ApplicationUser user;
            if(!string.IsNullOrEmpty(UserName))
            {
                user = _userRepository.GetByName(UserName);
            }
            else
            {
                UserName = _sessionUser.UserName;
                user = _userRepository.GetByName(UserName);
            }
            return user;
        }
        

        public ReturnMessage Remove(ApplicationUser entity)
        {
            _isSaveChanges = _userRepository.Remove(entity);
            if (_isSaveChanges)
            {
                _returnMessage = ReturnMessage.SetSuccessMessage();
            }
            else
            {
                _returnMessage = ReturnMessage.SetErrorMessage();
            }
            return _returnMessage;
        }

        public ReturnMessage SuperAdminValidate(UserLogin login, out ApplicationUser user)
        {
            return _userRepository.SuperAdminLogin(login, out user);
        }

        public ReturnMessage Update(ApplicationUser entity)
        {
            entity.SetDate = DateTime.Now;
            entity.EntryUserName = "sa";
            _isSaveChanges = _userRepository.Update(entity);
            if (_isSaveChanges)
            {
                _returnMessage = ReturnMessage.SetUpdateSuccessMessage();
            }
            else
            {
                _returnMessage = ReturnMessage.SetErrorMessage();
            }
            return _returnMessage;
        }

        public ReturnMessage ValidateBackOfficeUser(UserLogin login, out ApplicationUser user)
        {
            user = new ApplicationUser();            
            ReturnMessage message;
            message = ReturnMessage.SetSuccessMessage("Valid User");
            try
            {
                var appSession = new AppSession();
                user = _userRepository.GetByName(login.UserName);

                if (user == null)
                {
                    message = ReturnMessage.SetErrorMessage("Invalid username or password");
                }
                else if (user.RoleId == 7)
                {
                    message = ReturnMessage.SetErrorMessage("Member account is not allowed in Back Office");
                }
                else
                {
                    if (DataEncryptionUtilities.GenerateDecryptedString(user.Password) == login.Password)
                    {
                        if (user.IsActive)
                        {
                            appSession.UserName = user.UserName;
                            appSession.RoleId = user.RoleId;
                            appSession.IsActive = user.IsActive;
                            appSession.UserId = user.UserId;
                            appSession.UserFullName = user.UserFullName;
                            appSession.UserEmail = user.Email;
                            HttpContext.Current.Session[AppSetting.Session] = appSession;
                            message = ReturnMessage.SetSuccessMessage("Success!");
                        }
                        else
                        {
                            message = ReturnMessage.SetErrorMessage("User is Inactive");
                        }
                    }
                    else
                    {
                        message = ReturnMessage.SetErrorMessage("Password not matching");
                    }



                    //if (!PasswordHash.ValidatePassword(login.Password, user.Password))
                    //{
                    //    message = ReturnMessage.SetErrorMessage("Invalid username or password");
                    //}
                    //else
                    //{
                    //    if (!user.IsActive)
                    //    {
                    //        message = ReturnMessage.SetErrorMessage("Account is in-active");
                    //    }
                    //}

                }

            }
            catch (Exception ex)
            {
                message = ReturnMessage.SetErrorMessage();
            }

            return message;
        }

        public ReturnMessage ValidateUser(UserLogin login, out ApplicationUser user)
        {
            user = new ApplicationUser(); 
            //MemberProfile memberProfile = new MemberProfile();
            
            ReturnMessage message;
            message = ReturnMessage.SetSuccessMessage("Valid User");
            try
            {
                var appSession = new AppSession();
                user = _userRepository.GetByName(login.UserName);
                
                if (user == null)
                {
                    message = ReturnMessage.SetErrorMessage("Invalid username or password");
                }
                else
                {
                    //int profileId = Convert.ToInt32(user.EmployeeID);
                    //memberProfile = new SqlQryManager().GetMemberProfileByLoginInfo(login.UserName, login.MemberBatchNo, login.MemberSubject);

                    if (DataEncryptionUtilities.GenerateDecryptedString(user.Password) == login.Password)
                    {
                        if (user.IsActive)
                        {
                            appSession.UserName = user.UserName;
                            appSession.RoleId = user.RoleId;
                            appSession.IsActive = user.IsActive;
                            appSession.UserId = user.UserId;
                            appSession.UserFullName = user.UserFullName;
                            appSession.UserEmail = user.Email;                            
                            HttpContext.Current.Session[AppSetting.Session] = appSession;
                            message = ReturnMessage.SetSuccessMessage("Success!");
                        }
                        else
                        {
                            message = ReturnMessage.SetErrorMessage("User is Inactive");
                        }
                    }
                    else
                    {
                        message = ReturnMessage.SetErrorMessage("Password not matching");
                    }




                    //if (!PasswordHash.ValidatePassword(login.Password, user.Password))
                    //{
                    //    message = ReturnMessage.SetErrorMessage("Invalid username or password");
                    //}
                    //else
                    //{
                    //    if (!user.IsActive)
                    //    {
                    //        message = ReturnMessage.SetErrorMessage("Account is in-active");
                    //    }
                    //}

                }

            }
            catch (Exception ex)
            {
                message = ReturnMessage.SetErrorMessage();
            }

            return message;
        }
    }
}
