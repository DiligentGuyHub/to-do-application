using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.Domain.Services;
using ToDo.EntityFramework;
using ToDo.WPF.Commands;
using ToDo.WPF.State.Accounts;
using ToDo.WPF.State.Tasks;

namespace ToDo.WPF.ViewModels
{
    public class TaskSummaryViewModel : ViewModelBase
    {
        public TaskStore _taskStore;
        private readonly ToDoDbContextFactory _contextFactory;
        private readonly ToDoDbContext _context;
        private readonly ITaskService _taskService;
        private readonly IAccountStore _accountStore;
        public ICommand UpdateTaskCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }
        public ICommand DuplicateTaskCommand { get; set; }

        private ObservableCollection<Domain.Models.Task> _tasks;
        public ObservableCollection<Domain.Models.Task> Tasks
        {
            get
            {
                return _tasks;
            }
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }
        private int selectedTask;
        public int SelectedTask
        {
            get
            {
                return selectedTask;
            }
            set
            {
                selectedTask = Tasks[value].Id;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }
        public TaskSummaryViewModel(TaskStore taskStore, ToDoDbContextFactory contextFactory, ITaskService taskService, IAccountStore accountStore)
        {
            _contextFactory = contextFactory;
            _context = _contextFactory.CreateDbContext();
            UpdateTaskCommand = new UpdateTaskCommand(taskService, accountStore);
            DeleteTaskCommand = new DeleteTaskCommand(this, taskService, accountStore);
            DuplicateTaskCommand = new DuplicateTaskCommand(this, taskService, accountStore);
            _taskService = taskService;
            _accountStore = accountStore;
            _taskStore = taskStore;
            _tasks = new ObservableCollection<Domain.Models.Task>(_context.Tasks.Local.ToBindingList());
            _taskStore.StateChanged += TaskStore_StateChanged;
            ResetTasks();

        }
        private void ResetTasks()
        {
            _context.SaveChangesAsync();

            //var taskViewModels = _taskStore.Tasks
            //    .Select(a => new TaskViewModel(a.Id, a.Header, (DateTime)a.Deadline, a.Category, a.Priority, a.isCompleted, a.Description));
            var taskViewModels = _taskStore.Tasks
                .Select(a => a);

            _tasks.Clear();
            foreach (Domain.Models.Task vm in taskViewModels)
            {
                _tasks.Add(vm);
            }

        }
        private void TaskStore_StateChanged()
        {
            OnPropertyChanged(nameof(Tasks));
            ResetTasks();
        }
    }
}
