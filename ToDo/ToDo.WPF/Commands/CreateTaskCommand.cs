using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToDo.Domain.Models;
using ToDo.Domain.Services;
using ToDo.WPF.State.Accounts;
using ToDo.WPF.State.Authenticators;
using ToDo.WPF.ViewModels;

namespace ToDo.WPF.Commands
{
    public class CreateTaskCommand : AsyncCommandBase
    {
        private ITaskService _taskService;
        private IAccountStore _accountStore;
        private IAccountService _accountService;
        private TodayViewModel _todayViewModel;
        private WeekViewModel _weekViewModel;
        private MonthViewModel _monthViewModel;


        public CreateTaskCommand(TodayViewModel todayViewModel, ITaskService taskService, IAccountStore accountStore, IAccountService accountService)
        {
            _todayViewModel = todayViewModel;
            _taskService = taskService;
            _accountStore = accountStore;
            _accountService = accountService;
        }
        public CreateTaskCommand(WeekViewModel weekViewModel, ITaskService taskService, IAccountStore accountStore, IAccountService accountService)
        {
            _weekViewModel = weekViewModel;
            _taskService = taskService;
            _accountStore = accountStore;
            _accountService = accountService;
        }
        public CreateTaskCommand(MonthViewModel monthViewModel, ITaskService taskService, IAccountStore accountStore, IAccountService accountService)
        {
            _monthViewModel = monthViewModel;
            _taskService = taskService;
            _accountStore = accountStore;
            _accountService = accountService;
        }
        public override async System.Threading.Tasks.Task ExecuteAsync(object parameter)
        {
            try
            {
                User user = new User();
                if (_todayViewModel != null)
                {
                    _todayViewModel.ErrorMessage = string.Empty;
                     user = await _taskService.CreateTask(_accountStore.CurrentAccount, _todayViewModel.Task, _todayViewModel.Category, _todayViewModel.Priority, DateTime.Now);
                }
                else if (_weekViewModel != null)
                {
                    _weekViewModel.ErrorMessage = string.Empty;
                    user = await _taskService.CreateTask(_accountStore.CurrentAccount, _weekViewModel.Task, _weekViewModel.Category, _weekViewModel.Priority, DateTime.Now);
                }
                else if (_monthViewModel != null)
                {
                    _monthViewModel.ErrorMessage = string.Empty;
                    user = await _taskService.CreateTask(_accountStore.CurrentAccount, _todayViewModel.Task, _monthViewModel.Category, _monthViewModel.Priority, DateTime.Now);
                }

                _accountStore.CurrentAccount = user;
            }
            catch (Exception)
            {
                if (_todayViewModel != null)
                {
                    _todayViewModel.ErrorMessage = "All fields must be specified to create a task";
                }
                else if (_weekViewModel != null)
                {
                    _weekViewModel.ErrorMessage = "All fields must be specified to create a task";
                }
                else if (_monthViewModel != null)
                {
                    _monthViewModel.ErrorMessage = "All fields must be specified to create a task";
                }
                
            }
        }
    }
}
