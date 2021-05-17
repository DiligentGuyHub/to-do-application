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
        private TodayViewModel _todayViewModel;
        public DeleteTaskCommand(TodayViewModel todayViewModel, ITaskService taskService, IAccountStore accountStore)
        {
            _todayViewModel = todayViewModel;
            _taskService = taskService;
            _accountStore = accountStore;
        }
        public override async System.Threading.Tasks.Task ExecuteAsync(object parameter)
        {
            _todayViewModel.ErrorMessage = string.Empty;

            try
            {
                //await _taskService.Delete();
            }
            catch (Exception)
            {
                _todayViewModel.ErrorMessage = "All fields must be specified to create a task";
            }
        }
    }
}
