using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Services;
using ToDo.WPF.State.Accounts;
using ToDo.WPF.ViewModels;

namespace ToDo.WPF.Commands
{
    public class UpdateTaskCommand : AsyncCommandBase
    {
        private ITaskService _taskService;
        private IAccountStore _accountStore;
        public UpdateTaskCommand(ITaskService taskService, IAccountStore accountStore)
        {
            _taskService = taskService;
            _accountStore = accountStore;
        }
        public override async System.Threading.Tasks.Task ExecuteAsync(object parameter)
        {
            User user = await _taskService.UpdateTask(_accountStore.CurrentAccount);

            _accountStore.CurrentAccount = user;
        }
    }
}
