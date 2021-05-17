using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.Domain.Services;
using ToDo.WPF.Commands;
using ToDo.WPF.State.Accounts;
using Task = ToDo.Domain.Models.Task;

namespace ToDo.WPF.ViewModels
{
    public class TaskDescriptionViewModel : ViewModelBase
    {
        private ITaskService _taskService;
        private IAccountStore _accountStore;

        private Task task;
        public Task Task
        {
            get
            {
                return task;
            }
            set
            {
                task = value;
                OnPropertyChanged(nameof(Task));
            }
        }
        public ICommand UpdateTaskCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }
        public ICommand DuplicateTaskCommand { get; set; }
        public TaskDescriptionViewModel(ITaskService taskService, IAccountStore accountStore)
        {
            UpdateTaskCommand = new UpdateTaskCommand(taskService, accountStore);
            DeleteTaskCommand = new DeleteTaskCommand(this, taskService, accountStore);
            DuplicateTaskCommand = new DuplicateTaskCommand(this, taskService, accountStore);
            _taskService = taskService;
            _accountStore = accountStore;
        }

    }
}
