using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.WPF.State.Accounts;
using ToDo.WPF.ViewModels;

namespace ToDo.WPF.Commands
{
    public class DuplicateTaskCommand : AsyncCommandBase
    {
        private readonly ITaskService _taskService;
        private readonly IAccountStore _accountStore;
        private readonly IAccountService _accountService;
        private readonly TaskSummaryViewModel _taskSummaryViewModel;
        public DuplicateTaskCommand(TaskSummaryViewModel taskSummaryViewModel, ITaskService taskService, IAccountService accountService, IAccountStore accountStore)
        {
            _taskSummaryViewModel = taskSummaryViewModel;
            _taskService = taskService;
            _accountService = accountService;
            _accountStore = accountStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            if ((string)parameter != "Description")
            {
                await _taskService.DuplicateTask(_accountStore.CurrentAccount, _taskSummaryViewModel.SelectedTaskInstance.Id);
                await _accountService.Update(_accountStore.CurrentAccount.Id, _accountStore.CurrentAccount);
            }
            else
            {

            }
            _accountStore.CurrentAccount = _accountStore.CurrentAccount;
        }
    }
}
