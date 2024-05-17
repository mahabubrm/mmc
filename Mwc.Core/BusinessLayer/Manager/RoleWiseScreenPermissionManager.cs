using Mwc.Core.BusinessLayer.Interface;
using Mwc.Core.DataLayer.Repository;
using Mwc.Core.Models;
using Mwc.Core.Models.Common;
using Mwc.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Mwc.Core.BusinessLayer.Manager
{
    public class RoleWiseScreenPermissionManager : IRoleWiseScreenPermissionManager
    {
        private RoleWiseScreenPermissionRepository _roleWisePermissionRepository;
        private ScreenRepository _screenRepository;
        public ReturnMessage _returnMessage;
        public bool _isSaveChanges;
        public RoleWiseScreenPermissionManager()
        {
            _roleWisePermissionRepository = new RoleWiseScreenPermissionRepository();
            _screenRepository = new ScreenRepository();
            _returnMessage = new ReturnMessage();
        }
        public ReturnMessage Add(RoleWiseScreenPermission entity)
        {
            var sessionUser = HttpContext.Current.Session[AppSetting.Session] as AppSession;
            entity.EntryUser = sessionUser.UserName;

            entity.EntryDate = DateTime.Now;
            _isSaveChanges = _roleWisePermissionRepository.Add(entity);
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

        public IEnumerable<RoleWiseScreenPermission> GetAll()
        {
            return _roleWisePermissionRepository.GetAll();
        }

        public RoleWiseScreenPermission GetById(int id)
        {
            return null;
        }

        public ReturnMessage Remove(RoleWiseScreenPermission entity)
        {
            _isSaveChanges = _roleWisePermissionRepository.Remove(entity);
            if (_isSaveChanges)
            {
                _returnMessage = ReturnMessage.SetDeleteSuccessMessage();
            }
            else
            {
                _returnMessage = ReturnMessage.SetErrorMessage();
            }
            return _returnMessage;
        }

        public ReturnMessage Update(RoleWiseScreenPermission entity)
        {
            _isSaveChanges = _roleWisePermissionRepository.Update(entity);
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

        public ReturnMessage UpdateRoleWisePermission(List<RoleWiseScreenPermission> roleWiseScreens)
        {
            var sessionUser = HttpContext.Current.Session[AppSetting.Session] as AppSession;
            try
            {
                foreach (var item in roleWiseScreens)
                {
                    if (item.IsCreate == false && item.IsRead == false && item.IsUpdate == false && item.IsDelete == false)
                    {

                    }
                    else
                    {
                        var getCurrentRole = _roleWisePermissionRepository.GetRoleWiseScreenPermission(item.RoleId, item.ScreenCode);
                        if (getCurrentRole != null)
                        {
                            //update                            
                            //item.SL = getCurrentRole.SL;
                            //item.AccessRightCode = (Convert.ToBoolean(item.IsCreate) ? 1 : 0).ToString() + (Convert.ToBoolean(item.IsRead) ? 1 : 0).ToString() + (Convert.ToBoolean(item.IsUpdate) ? 1 : 0).ToString() + (Convert.ToBoolean(item.IsDelete) ? 1 : 0).ToString();
                            //_isSaveChanges = _roleWisePermissionRepository.Update(item);
                            _isSaveChanges = _roleWisePermissionRepository.Remove(getCurrentRole);
                            if(_isSaveChanges)
                            {
                                item.EntryUser = sessionUser.UserName;
                                item.EntryDate = DateTime.Now;
                                item.AccessRightCode = (Convert.ToBoolean(item.IsCreate) ? 1 : 0).ToString() + (Convert.ToBoolean(item.IsRead) ? 1 : 0).ToString() + (Convert.ToBoolean(item.IsUpdate) ? 1 : 0).ToString() + (Convert.ToBoolean(item.IsDelete) ? 1 : 0).ToString();
                                _isSaveChanges = _roleWisePermissionRepository.Add(item);
                            }
                        }
                        else
                        {
                            //insert
                            item.EntryUser = sessionUser.UserName;
                            item.EntryDate = DateTime.Now;
                            item.AccessRightCode = (Convert.ToBoolean(item.IsCreate) ? 1 : 0).ToString() + (Convert.ToBoolean(item.IsRead) ? 1 : 0).ToString() + (Convert.ToBoolean(item.IsUpdate) ? 1 : 0).ToString() + (Convert.ToBoolean(item.IsDelete) ? 1 : 0).ToString();
                            _isSaveChanges = _roleWisePermissionRepository.Add(item);
                        }
                    }
                }
                if (_isSaveChanges)
                {
                    _returnMessage = ReturnMessage.SetUpdateSuccessMessage();
                }
                else
                {
                    _returnMessage = ReturnMessage.SetErrorMessage();
                }
            }
            catch(Exception ex)
            {
                _returnMessage = ReturnMessage.SetErrorMessage();
            }
            
            return _returnMessage;
        }

        public IEnumerable<RoleWisePermissionViewModel> GetRoleWisePermission(int roleId, string parentScreenCode)
        {
            List<RoleWisePermissionViewModel> roleWisePermissions = new List<RoleWisePermissionViewModel>();
            var screens = _screenRepository.GetAll().Where(o => o.ModuleId == parentScreenCode).ToList();
            foreach(var item in screens)
            {
                RoleWisePermissionViewModel model = new RoleWisePermissionViewModel();
                var roleWisePermission = _roleWisePermissionRepository.GetRoleWiseScreenPermission(roleId, item.ScreenCode);
                if (roleWisePermission != null)
                {                    
                    model.ScreenCode = roleWisePermission.ScreenCode;
                    model.ScreenName = screens.Where(o => o.ScreenCode == roleWisePermission.ScreenCode).FirstOrDefault().ScreenName;
                    model.IsCreate = Convert.ToBoolean(roleWisePermission.IsCreate);
                    model.IsRead = Convert.ToBoolean(roleWisePermission.IsRead);
                    model.IsUpdate = Convert.ToBoolean(roleWisePermission.IsUpdate);
                    model.IsDelete = Convert.ToBoolean(roleWisePermission.IsDelete);
                    roleWisePermissions.Add(model);
                }
                else
                {
                    model.ScreenCode = item.ScreenCode;
                    model.ScreenName = item.ScreenName;
                    model.IsCreate = false;
                    model.IsRead = false;
                    model.IsUpdate = false;
                    model.IsDelete = false;
                    roleWisePermissions.Add(model);
                }
            }
            return roleWisePermissions;
        }

        public IEnumerable<MenuViewModel> GetMenuByUserRole(int roleId)
        {
            List<MenuViewModel> Menus = new List<MenuViewModel>();
            var roleWisePermission = _roleWisePermissionRepository.GetAll().Where(o => o.RoleId == roleId).OrderBy(j => j.ScreenCode).ToList();
            if (roleWisePermission.Count() > 0)
            {
                foreach(var item in roleWisePermission)
                {
                    MenuViewModel menuModel = new MenuViewModel();
                    var screen = _screenRepository.GetAll().Where(o => o.ScreenCode.Trim() == item.ScreenCode.Trim()).FirstOrDefault();
                    menuModel.MenuCode = item.ScreenCode;
                    menuModel.MenuName = screen.ScreenName;
                    menuModel.MenuParentID = screen.ParentScreenCode;
                    menuModel.MenuURL = screen.URL;
                    menuModel.ModuleId = screen.ModuleId;
                    menuModel.MenuIcon = screen.MenuIcon;
                    menuModel.IsRequiredForApproval = screen.IsRequiredForApproval;
                    menuModel.IsEmailNotificationSend = (bool)screen.IsEmailNotificationSend;
                    Menus.Add(menuModel);
                }
            }
            return Menus;
        }
    }
}
