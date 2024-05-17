using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.DataLayer.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        T GetById(int id);       
        IEnumerable<T> GetAll();

        
    }
}
