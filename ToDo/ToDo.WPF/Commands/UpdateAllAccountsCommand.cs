using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Services;
using ToDo.WPF.ViewModels;
using Task = System.Threading.Tasks.Task;

namespace ToDo.WPF.Commands
{
    public class UpdateAllAccountsCommand : AsyncCommandBase
    {
        private readonly IAccountService _accountService;
        private readonly AccountViewModel _accountViewModel;
        public UpdateAllAccountsCommand(AccountViewModel accountViewModel, IAccountService accountService)
        {
            _accountService = accountService;
            _accountViewModel = accountViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                foreach(User account in (IEnumerable<User>)parameter)
                {
                    await _accountService.Update(account.Id, account);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
