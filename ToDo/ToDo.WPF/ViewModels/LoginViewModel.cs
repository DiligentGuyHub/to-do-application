using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.WPF.Commands;
using ToDo.WPF.State.Authenticators;
using ToDo.WPF.State.Navigators;

namespace ToDo.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
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
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage { set => ErrorMessageViewModel.Message = value; }
        public ICommand LoginCommand { get; }
        public ICommand ViewRegisterCommand { get; }
        public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator, IRenavigator registerRenavigator, MessageViewModel errorMessageViewModel)
        {
            LoginCommand = new LoginCommand(authenticator, this, loginRenavigator);
            ErrorMessageViewModel = errorMessageViewModel;
            ViewRegisterCommand = new RenavigateCommand(registerRenavigator);
        }

    }
}
