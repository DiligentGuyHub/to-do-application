using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetJoin(Func<T, bool> func, params Expression<Func<T, object>>[] expressions);
        Task<ICollection<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}
