using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using Task = System.Threading.Tasks.Task;

namespace ToDo.WPF.State.Common
{
    public interface IGenericStore<T> where T : DomainBase
    {
        List<T> Domains { get; set; }
        Task LoadWithJoin(Func<T, bool> func, params Expression<Func<T, object>>[] expressions);
        event Action StateChanged;
    }
}
