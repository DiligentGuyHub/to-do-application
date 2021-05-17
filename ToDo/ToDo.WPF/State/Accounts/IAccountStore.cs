using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.WPF.State.Accounts
{
    public interface IAccountStore
    {
        User CurrentAccount { get; set; }
        event Action StateChanged;
    }
}
