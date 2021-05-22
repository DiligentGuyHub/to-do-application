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
    public class DeleteTaskCommand : AsyncCommandBase
    {
        private ITaskService _taskService;
        private IAccountStore _accountStore;
        private TaskSummaryViewModel _taskSummaryViewModel;
        public DeleteTaskCommand(TaskSummaryViewModel taskSummaryViewModel, ITaskService taskService, IAccountStore accountStore)
        {
            _taskSummaryViewModel = taskSummaryViewModel;
            _taskService = taskService;
            _accountStore = accountStore;
        }
        public override async System.Threading.Tasks.Task ExecuteAsync(object parameter)
        {
            try
            {
                if((string)parameter != "Description")
                {
                    await _taskService.DeleteTask(_accountStore.CurrentAccount, _taskSummaryViewModel.SelectedTaskInstance.Id);
                }
                else
                {

                }

                _accountStore.CurrentAccount = _accountStore.CurrentAccount;
            }
            catch(Exception e)
            {

            }
        }
    }
}
