using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.Domain.Exceptions;
using ToDo.WPF.State.Authenticators;
using ToDo.WPF.State.Navigators;
using ToDo.WPF.ViewModels;
using ToDo.WPF.ViewModels.Factories;

namespace ToDo.WPF.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IRenavigator _renavigator;
        private readonly IAuthenticator _authenticator;

        public LoginCommand(IAuthenticator authenticator, LoginViewModel loginViewModel, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _loginViewModel = loginViewModel;
            _renavigator = renavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _loginViewModel.ErrorMessage = string.Empty;

            try
            {
                await _authenticator.Login(_loginViewModel.Username, _loginViewModel.Password);

                _renavigator.Renavigate();
            }
            catch(InvalidLoginOrPasswordException)
            {
                _loginViewModel.ErrorMessage = "Username and/or password is incorrect.";
            }
        }
    }
}
