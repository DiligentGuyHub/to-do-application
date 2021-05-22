using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Services;
using ToDo.WPF.State.Accounts;
using Task = System.Threading.Tasks.Task;

namespace ToDo.WPF.State.Common
{
    public class GenericStore<T> : IGenericStore<T> where T : DomainBase
    {
        private readonly IDataService<T> _dataService;
        //private readonly IAccountStore _accountStore;

        public GenericStore(IDataService<T> dataService)
        {
            _dataService = dataService;
            //_accountStore = accountStore;
            //_accountStore.StateChanged += OnStateChanged;
        }

        //private void OnStateChanged()
        //{
        //    StateChanged?.Invoke();
        //}

        public List<T> Domains { get; set; }

        public event Action StateChanged;

        public async Task LoadWithJoin(Func<T, bool> func, params Expression<Func<T, object>>[] expressions)
        {
            Domains = new List<T>(await _dataService.GetJoin(func, expressions));
        }
    }
}
