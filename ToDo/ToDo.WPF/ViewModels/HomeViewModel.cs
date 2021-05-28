using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using ToDo.WPF.State.Authenticators;

namespace ToDo.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public TaskSummaryViewModel TaskSummaryViewModel { get; }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _actualTime;
        public string actualTime
        {
            get
            {
                return _actualTime;
            }
            set
            {
                _actualTime = value;
                OnPropertyChanged(nameof(actualTime));
            }
        }

        private string _actualGreeting;
        public string actualGreeting
        {
            get
            {
                return _actualGreeting;
            }
            set
            {
                _actualGreeting = value;
                OnPropertyChanged(nameof(actualGreeting));
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
        public ExchangeRateListingViewModel ExchangeRateListingViewModel { get; set; }
        public IAuthenticator Authenticator { get; }

        public HomeViewModel(ExchangeRateListingViewModel exchangeRateViewModel, IAuthenticator authenticator, TaskSummaryViewModel taskSummaryViewModel)
        {
            ExchangeRateListingViewModel = exchangeRateViewModel;
            TaskSummaryViewModel = taskSummaryViewModel;
            Authenticator = authenticator;
            Username = authenticator.CurrentUser.Username;
            actualTime = DateTime.Now.ToString("HH:mm");
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 6)
                actualGreeting = $"Ну привет, полуночный странник";
            else if (DateTime.Now.Hour > 6 && DateTime.Now.Hour <= 12)
                actualGreeting = $"Доброе утро, {Username}";
            else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour <= 16)
                actualGreeting = $"Добрый день, {Username}";
            else if (DateTime.Now.Hour > 16)
                actualGreeting = $"Добрый вечер, {Username}";
            StartTimer();
        }
        private void StartTimer()
        {
            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 5)
            };
            timer.Tick += new EventHandler(GetActualTime);
            timer.Start();
        }

        private void GetActualTime(object sender, EventArgs e)
        {
            actualTime = DateTime.Now.ToString("HH:mm");
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 6)
                actualGreeting = $"Ну привет, полуночный странник";
            else if (DateTime.Now.Hour > 6 && DateTime.Now.Hour <= 12)
                actualGreeting = $"Доброе утро, {Username}";
            else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour <= 16)
                actualGreeting = $"Добрый день, {Username}";
            else if (DateTime.Now.Hour > 16)
                actualGreeting = $"Добрый вечер, {Username}";
        }
    }
}
