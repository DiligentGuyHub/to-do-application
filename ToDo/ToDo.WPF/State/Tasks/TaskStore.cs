using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WPF.State.Accounts;

namespace ToDo.WPF.State.Tasks
{
    public class TaskStore
    {
        private IAccountStore _accountStore;

        public IEnumerable<ToDo.Domain.Models.Task> Tasks => _accountStore.CurrentAccount?.Tasks ?? new List<ToDo.Domain.Models.Task>();

        public event Action StateChanged;
        public TaskStore(IAccountStore accountStore)
        {
            _accountStore = accountStore;

            _accountStore.StateChanged += OnStateChanged;
        }

        private void OnStateChanged()
        {
            StateChanged?.Invoke();
        }
    }
}
