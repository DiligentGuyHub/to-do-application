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
using ToDo.WPF.State.Navigators;
using ToDo.WPF.State.Tasks;
using ToDo.WPF.ViewModels.Factories;

namespace ToDo.WPF.ViewModels
{
    public class TaskSummaryViewModel : ViewModelBase
    {
        public TaskStore _taskStore;
        private INavigator _navigator;
        private IToDoViewModelFactory _viewModelFactory;
        private readonly ToDoDbContextFactory _contextFactory;
        private readonly ToDoDbContext _context;
        private readonly ITaskService _taskService;
        private readonly IAccountStore _accountStore;
        public ICommand UpdateTaskCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }
        public ICommand DuplicateTaskCommand { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; }

        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

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
        private Domain.Models.Task selectedTaskInstance;
        public Domain.Models.Task SelectedTaskInstance
        {
            get
            {
                return selectedTaskInstance;
            }
            set
            {
                selectedTaskInstance = value;
                OnPropertyChanged(nameof(SelectedTaskInstance));
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
                if (value != -1)
                {
                    selectedTask = Tasks[value].Id;
                }
                SelectedTaskInstance = Tasks.Where(item => item.Id == selectedTask).FirstOrDefault();
                OnPropertyChanged(nameof(SelectedTask));
            }
        }


        public TaskSummaryViewModel(TaskStore taskStore, ToDoDbContextFactory contextFactory, ITaskService taskService, IAccountStore accountStore, INavigator navigator, IToDoViewModelFactory viewModelFactory)
        {
            _contextFactory = contextFactory;
            _navigator = navigator;
            _navigator.StateChanged += Navigator_StateChanged;

            _viewModelFactory = viewModelFactory;
            _context = _contextFactory.CreateDbContext();
            UpdateTaskCommand = new UpdateTaskCommand(taskService, accountStore);
            DeleteTaskCommand = new DeleteTaskCommand(this, taskService, accountStore);
            DuplicateTaskCommand = new DuplicateTaskCommand(this, taskService, accountStore);
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_navigator, _viewModelFactory);
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
        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
