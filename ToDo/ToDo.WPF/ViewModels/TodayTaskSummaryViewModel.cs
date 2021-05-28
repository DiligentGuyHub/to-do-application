using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.Domain.Models;
using ToDo.Domain.Services;
using ToDo.EntityFramework;
using ToDo.WPF.State.Accounts;
using ToDo.WPF.State.Common;
using ToDo.WPF.State.Navigators;
using ToDo.WPF.State.Tasks;
using ToDo.WPF.ViewModels.Factories;
using Task = ToDo.Domain.Models.Task;

namespace ToDo.WPF.ViewModels
{
    public class TodayTaskSummaryViewModel : ViewModelBase
    {
        private readonly ToDoDbContext _context;
        private readonly ToDoDbContextFactory _contextFactory;
        private readonly IToDoViewModelFactory _viewModelFactory;

        private readonly INavigator _navigator;

        private readonly ITaskService _taskService;
        private readonly IFileService _fileService;
        private readonly IImageService _imageService;

        private readonly IGenericStore<AttachedImage> _imageStore;
        private readonly IGenericStore<AttachedFile> _fileStore;
        private readonly TaskStore _taskStore;
        private readonly IAccountStore _accountStore;

        public ICommand UpdateTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }
        public ICommand DuplicateTaskCommand { get; }
        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand UploadImageCommand { get; }
        public ICommand UploadFileCommand { get; }

        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        private ObservableCollection<Task> _tasks;
        public ObservableCollection<Task> Tasks => _tasks;

        private List<AttachedImage> _images;
        public List<AttachedImage> Images
        {
            get
            {
                return _images;
            }
            set
            {
                _images = value;
                OnPropertyChanged(nameof(Images));
            }
        }

        private List<AttachedFile> _files;
        public List<AttachedFile> Files
        {
            get
            {
                return _files;
            }
            set
            {
                _files = value;
                OnPropertyChanged(nameof(Files));
            }
        }

        private Task selectedTaskInstance;
        public Task SelectedTaskInstance
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

        private int _selectedTask;
        public int SelectedTask
        {
            get
            {
                return _selectedTask;
            }
            set
            {
                _selectedTask = Tasks[value].Id;
                SelectedTaskInstance = Tasks.Where(item => item.Id == _selectedTask).FirstOrDefault();

                // uploading attached images for selected task
                _imageStore.LoadWithJoin(item => item.TaskId == _selectedTask);
                Images = _imageStore.Domains;
                // uploading attached files for selected task
                _fileStore.LoadWithJoin(item => item.TaskId == _selectedTask);
                Files = _fileStore.Domains;

                OnPropertyChanged(nameof(SelectedTask));
            }
        }

        public IImageService ImageService => _imageService;

        public TodayTaskSummaryViewModel(TaskStore taskStore, ToDoDbContextFactory contextFactory, ITaskService taskService, IAccountStore accountStore, IAccountService accountService, INavigator navigator, IToDoViewModelFactory viewModelFactory, IImageService imageService, IFileService fileService)
        {
            _contextFactory = contextFactory;
            _navigator = navigator;
            _navigator.StateChanged += Navigator_StateChanged;


            _viewModelFactory = viewModelFactory;
            _context = _contextFactory.CreateDbContext();
            //UploadImageCommand = new UploadImageCommand(accountStore, this, imageService, accountService);
            //UploadFileCommand = new UploadFileCommand(accountStore, this, fileService, accountService);
            //UpdateTaskCommand = new UpdateTaskCommand(taskService, accountStore, accountService);
            //DeleteTaskCommand = new DeleteTaskCommand(this, taskService, accountStore);
            //DuplicateTaskCommand = new DuplicateTaskCommand(this, taskService, accountService, accountStore);
            //UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_navigator, _viewModelFactory);

            _taskService = taskService;
            _accountStore = accountStore;
            _taskStore = taskStore;
            _imageService = imageService;
            _fileService = fileService;

            _imageStore = new GenericStore<AttachedImage>(_imageService);
            _fileStore = new GenericStore<AttachedFile>(_fileService);

            _tasks = new ObservableCollection<Task>(_context.Tasks.Local.ToBindingList());
            _taskStore.StateChanged += TaskStore_StateChanged;
            ResetTasks();
        }
        private void ResetTasks()
        {
            _context.SaveChangesAsync();
           //List<Task> taskViewModels = (List<Task>)_taskService.GetJoin(item => item.Deadline.Day == DateTime.Now.Day).Result;
           List<Task> taskViewModels = _taskStore.Tasks.Where(item => item.Deadline.Day == DateTime.Now.Day).ToList();

            _tasks.Clear();
            foreach (Task vm in taskViewModels)
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
