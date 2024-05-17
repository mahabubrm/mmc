using Mwc.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.BusinessLayer.Interface
{
    public interface IManager<T> where T : class
    {
        ReturnMessage Add(T entity);
        ReturnMessage Update(T entity);
        ReturnMessage Remove(T entity);
        T GetById(int id);        
        IEnumerable<T> GetAll();
    }
}
