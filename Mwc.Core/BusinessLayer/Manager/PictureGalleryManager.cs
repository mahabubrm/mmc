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

namespace Mwc.Core.BusinessLayer.Manager
{
    public class PictureGalleryManager : IPictureGalleryManager
    {
        public PictureGalleryRepository _puctureGalleryRepository;
        public ReturnMessage _returnMessage;
        public bool _isSaveChanges;
        private AppSession _sessionUser = null;
        public PictureGalleryManager()
        {
            _puctureGalleryRepository = new PictureGalleryRepository();
            _returnMessage = new ReturnMessage();
            _sessionUser = HttpContext.Current.Session[AppSetting.Session] as AppSession;
        }
        public ReturnMessage Add(PictureGallery entity)
        {
            try
            {
                _isSaveChanges = _puctureGalleryRepository.Add(entity);
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

        public IEnumerable<PictureGallery> GetAll()
        {
            return _puctureGalleryRepository.GetAll();
        }

        public PictureGallery GetById(int id)
        {
            return _puctureGalleryRepository.GetById(id);
        }

        public ReturnMessage Remove(PictureGallery entity)
        {
            try
            {
                _isSaveChanges = _puctureGalleryRepository.Remove(entity);
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

        public ReturnMessage Update(PictureGallery entity)
        {
            try
            {
                _isSaveChanges = _puctureGalleryRepository.Update(entity);
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
    }
}
