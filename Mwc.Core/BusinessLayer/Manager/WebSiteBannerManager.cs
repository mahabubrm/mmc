using Mwc.Core.BusinessLayer.Interface;
using Mwc.Core.DataLayer.Repository;
using Mwc.Core.Models;
using Mwc.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.BusinessLayer.Manager
{
    public class WebSiteBannerManager : IWebSiteBannerManager
    {
        public WebSiteBannerRepository _websiteBannerRepository;
        public ReturnMessage _returnMessage;
        public bool _isSaveChanges;
        public WebSiteBannerManager()
        {
            _websiteBannerRepository = new WebSiteBannerRepository();
            _returnMessage = new ReturnMessage();
        }
        public ReturnMessage Add(WebSiteBanner entity)
        {
            try
            {
                _isSaveChanges = _websiteBannerRepository.Add(entity);
                if (_isSaveChanges)
                {
                    _returnMessage = ReturnMessage.SetSuccessMessage();
                }
                else
                {
                    _returnMessage = ReturnMessage.SetErrorMessage();
                }
            }
            catch (Exception ex)
            {
                _returnMessage = ReturnMessage.SetErrorMessage();
            }
            return _returnMessage;
        }

        public IEnumerable<WebSiteBanner> GetAll()
        {
            return _websiteBannerRepository.GetAll();
        }

        public WebSiteBanner GetById(int id)
        {
            return _websiteBannerRepository.GetById(id);
        }

        public ReturnMessage Remove(WebSiteBanner entity)
        {
            try
            {
                _isSaveChanges = _websiteBannerRepository.Remove(entity);
                if (_isSaveChanges)
                {
                    _returnMessage = ReturnMessage.SetDeleteSuccessMessage();
                }
                else
                {
                    _returnMessage = ReturnMessage.SetErrorMessage();
                }
            }
            catch (Exception ex)
            {
                _returnMessage = ReturnMessage.SetErrorMessage();
            }
            return _returnMessage;
        }

        public ReturnMessage Update(WebSiteBanner entity)
        {
            try
            {
                _isSaveChanges = _websiteBannerRepository.Update(entity);
                if (_isSaveChanges)
                {
                    _returnMessage = ReturnMessage.SetUpdateSuccessMessage();
                }
                else
                {
                    _returnMessage = ReturnMessage.SetErrorMessage();
                }
            }
            catch (Exception ex)
            {
                _returnMessage = ReturnMessage.SetErrorMessage();
            }
            return _returnMessage;
        }
    }
}
