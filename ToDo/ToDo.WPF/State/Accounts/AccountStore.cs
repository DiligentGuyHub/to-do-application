using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.WPF.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        private User _currentAccount;
        public User CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            set
            {
                _currentAccount = value;
                StateChanged?.Invoke();
            }
        }
        public event Action StateChanged;
    }
}
