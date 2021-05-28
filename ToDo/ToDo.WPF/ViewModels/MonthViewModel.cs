using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using ToDo.Domain.Services;
using ToDo.WPF.State.Accounts;

namespace ToDo.WPF.ViewModels
{
    public class MonthViewModel : ViewModelBase
    {
        public TaskSummaryViewModel TaskSummaryViewModel { get; }

        private string _task;
        public string Task
        {
            get
            {
                return _task;
            }
            set
            {
                _task = value;
                OnPropertyChanged(nameof(Task));
            }
        }

        private string _category;
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        private string _priority;
        public string Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
                OnPropertyChanged(nameof(Priority));
            }
        }

        private string _actualDay;
        public string actualDay
        {
            get
            {
                return _actualDay;
            }
            set
            {
                _actualDay = value;
                OnPropertyChanged(nameof(actualDay));
            }
        }

        private string _actualWeekDay;
        public string actualWeekDay
        {
            get
            {
                return _actualWeekDay;
            }
            set
            {
                _actualWeekDay = value;
                OnPropertyChanged(nameof(actualWeekDay));
            }
        }

        private DispatcherTimer _timer;
        public DispatcherTimer timer
        {
            get
            {
                return _timer;
            }
            set
            {
                _timer = value;
                OnPropertyChanged(nameof(timer));
            }
        }
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage { set => ErrorMessageViewModel.Message = value; }
        // PROPERTIES END

        public ICommand CreateTaskCommand { get; set; }
        public MonthViewModel(ITaskService taskService, IAccountStore accountStore, IAccountService accountService, TaskSummaryViewModel taskViewModel, MessageViewModel errorMessageViewModel)
        {
            //CreateTaskCommand = new CreateTaskCommand(this, taskService, accountStore, accountService);
            actualDay = DateTime.Now.ToString("dd");
            actualWeekDay = DateTime.Now.ToString("dddd");
            StartTimer();
            TaskSummaryViewModel = taskViewModel;
            ErrorMessageViewModel = errorMessageViewModel;
        }

        private void StartTimer()
        {
            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 1, 0)
            };
            timer.Tick += new EventHandler(GetActualTime);
            timer.Start();
        }
        private void GetActualTime(object sender, EventArgs e)
        {
            actualDay = DateTime.Now.ToString("dd");
            actualWeekDay = DateTime.Now.ToString("dddd");
        }
    }
}
