

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

namespace Mwc.Core.BusinessLayer.Manager
{
    public class WebsiteNoticeManager : IWebsiteNoticeManager
    {
        public WebsiteNoticeRepository _websiteNoticeRepository;
        public ReturnMessage _returnMessage;
        public bool _isSaveChanges;
        public WebsiteNoticeManager()
        {
            _websiteNoticeRepository = new WebsiteNoticeRepository();
            _returnMessage = new ReturnMessage();
        }

        public ReturnMessage Add(Website_Notice entity)
        {
            try
            {
                _isSaveChanges = _websiteNoticeRepository.Add(entity);
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

        public IEnumerable<Website_Notice> GetAll()
        {
            return _websiteNoticeRepository.GetAll();
        }

        public IEnumerable<NoticeViewModel> GetAllNotice(string nType)
        {
            var notices = _websiteNoticeRepository.GetAll().Where(o => o.NoticeType.Trim().Equals(nType.Trim())).ToList();
            List<NoticeViewModel> noticeList = new List<NoticeViewModel>();
            if (notices != null)
            {
                foreach(var item in notices)
                {
                    NoticeViewModel model = new NoticeViewModel();
                    model.NoticeId = item.NoticeId;
                    model.NoticeTitle = item.NoticeTitle;
                    model.NoticeDate = (DateTime)item.NoticeDate;
                    model.NoticeType = item.NoticeType;
                    model.TotalView = 0;
                    noticeList.Add(model);
                }
            }
            return noticeList.OrderByDescending(o => o.NoticeId);
        }

        public Website_Notice GetById(int id)
        {
            return _websiteNoticeRepository.GetById(id);
        }

        public ReturnMessage Remove(Website_Notice entity)
        {
            try
            {
                _isSaveChanges = _websiteNoticeRepository.Remove(entity);
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

        public ReturnMessage Update(Website_Notice entity)
        {
            try
            {
                _isSaveChanges = _websiteNoticeRepository.Update(entity);
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
