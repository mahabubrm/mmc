using Mwc.Core.BusinessLayer.Interface;
using Mwc.Core.DataLayer.Repository;
using Mwc.Core.Models;
using Mwc.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mwc.Core.BusinessLayer.Manager
{
    public class UserRoleManager : IUserRoleManager
    {
        public UserRoleRepository _userRoleRepository;
        public ReturnMessage _returnMessage;
        public bool _isSaveChanges;
        public UserRoleManager()
        {
            _userRoleRepository = new UserRoleRepository();
            _returnMessage = new ReturnMessage();
        }

        public ReturnMessage Add(UserRoleList entity)
        {
            var sessionUser = HttpContext.Current.Session[AppSetting.Session] as AppSession;
            entity.SetDate = DateTime.Now;
            entity.UserName = sessionUser.UserName;
            _isSaveChanges = _userRoleRepository.Add(entity);
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

        public IEnumerable<UserRoleList> GetAll()
        {
            return _userRoleRepository.GetAll();
        }

        public IEnumerable<SelectListItem> GetAllRoleName()
        {
            return _userRoleRepository.GetAllRoleName();
        }

        public UserRoleList GetById(int id)
        {
            return _userRoleRepository.GetById(id);
        }

        public ReturnMessage Remove(UserRoleList entity)
        {
            _isSaveChanges = _userRoleRepository.Remove(entity);
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

        public ReturnMessage Update(UserRoleList entity)
        {
            _isSaveChanges = _userRoleRepository.Update(entity);
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
    }
}
