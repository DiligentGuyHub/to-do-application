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
        private ITaskService _taskService;
        private IAccountStore _accountStore;
        private TaskSummaryViewModel _taskSummaryViewModel;
        private TaskDescriptionViewModel _taskDescriptionViewModel;
        public DuplicateTaskCommand(TaskSummaryViewModel taskSummaryViewModel, ITaskService taskService, IAccountStore accountStore)
        {
            _taskSummaryViewModel = taskSummaryViewModel;
            _taskService = taskService;
            _accountStore = accountStore;
        }
        public DuplicateTaskCommand(TaskDescriptionViewModel taskDescriptionViewModel, ITaskService taskService, IAccountStore accountStore)
        {
            _taskDescriptionViewModel = taskDescriptionViewModel;
            _taskService = taskService;
            _accountStore = accountStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            if ((string)parameter != "Description")
            {
                await _taskService.DuplicateTask(_accountStore.CurrentAccount, _taskSummaryViewModel.SelectedTask);
            }
            else
            {

            }
            _accountStore.CurrentAccount = _accountStore.CurrentAccount;
        }
    }
}
