using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Services;
using ToDo.WPF.State.Accounts;
using ToDo.WPF.ViewModels;
using Task = System.Threading.Tasks.Task;

namespace ToDo.WPF.Commands
{
    public class UpdateTaskCommand : AsyncCommandBase
    {
        private readonly ITaskService _taskService;
        private readonly IAccountStore _accountStore;
        private readonly IAccountService _accountService;

        public UpdateTaskCommand(ITaskService taskService, IAccountStore accountStore, IAccountService accountService)
        {
            _taskService = taskService;
            _accountStore = accountStore;
            _accountService = accountService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            await _accountService.Update(_accountStore.CurrentAccount.Id, _accountStore.CurrentAccount);
        }
    }
}
