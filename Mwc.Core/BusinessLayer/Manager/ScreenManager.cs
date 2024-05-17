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
    public class ScreenManager : IScreenManager
    {
        private ScreenRepository _screenRepository;
        public ReturnMessage _returnMessage;
        public bool _isSaveChanges;
        public ScreenManager()
        {
            _screenRepository = new ScreenRepository();
            _returnMessage = new ReturnMessage();
        }
        public ReturnMessage Add(Screen entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Screen> GetAll()
        {
            return _screenRepository.GetAll();
        }

        public Screen GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ReturnMessage Remove(Screen entity)
        {
            throw new NotImplementedException();
        }

        public ReturnMessage Update(Screen entity)
        {
            throw new NotImplementedException();
        }

        public Screen GetScreenByScreenCode(string code)
        {
            return _screenRepository.GetAll().Where(o => o.ScreenCode == code).FirstOrDefault();
        }

        public IEnumerable<Screen> GetAllScreenByParentScreenCode(string parentScreenCode)
        {
            return _screenRepository.GetAll().Where(o => o.ParentScreenCode == parentScreenCode).ToList();
        }
        
    }
}
