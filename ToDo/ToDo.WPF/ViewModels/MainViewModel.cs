using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.WPF.Commands;
using ToDo.WPF.State.Authenticators;
using ToDo.WPF.State.Navigators;
using ToDo.WPF.ViewModels.Factories;

namespace ToDo.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IToDoViewModelFactory _viewModelFactory;
        private INavigator _navigator;
        private IAuthenticator _authenticator;
        public ICommand UpdateCurrentViewModelCommand { get; }

        public bool IsLoggedIn => _authenticator.IsLoggedIn;

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
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public MainViewModel(INavigator navigator, IToDoViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
            if(IsLoggedIn)
            {
                Username = _authenticator.CurrentUser.Username;
            }

        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
