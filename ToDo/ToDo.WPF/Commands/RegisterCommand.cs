using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.WPF.State.Authenticators;
using ToDo.WPF.State.Navigators;
using ToDo.WPF.ViewModels;

namespace ToDo.WPF.Commands
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public RegisterCommand(RegisterViewModel registerViewModel, IAuthenticator authenticator, IRenavigator renavigator)
        {
            _registerViewModel = registerViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _registerViewModel.ErrorMessage = string.Empty;

            RegistrationResult registrationResult = await _authenticator.Register(
                _registerViewModel.Email,
                _registerViewModel.Username,
                _registerViewModel.Password,
                _registerViewModel.ConfirmPassword);

            switch (registrationResult)
            {
                case RegistrationResult.Success:
                    _renavigator.Renavigate();
                    break;
                case RegistrationResult.PasswordsDoNotMatch:
                    _registerViewModel.ErrorMessage = "Confirm password does not match origin password.";
                    break;
                case RegistrationResult.EmailAlreadyExists:
                    _registerViewModel.ErrorMessage = "An account with this email already exists.";
                    break;
                case RegistrationResult.UsernameAlreadyExists:
                    _registerViewModel.ErrorMessage = "An account with this username already exists.";
                    break;
                default:
                    _registerViewModel.ErrorMessage = "Registration failed.";
                    break;
            }
        }
    }
}
