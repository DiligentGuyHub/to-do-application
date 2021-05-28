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
                case RegistrationResult.EmptyFields:
                    _registerViewModel.ErrorMessage = "Все поля должны быть верно заполнены";
                    break;
                case RegistrationResult.PasswordsDoNotMatch:
                    _registerViewModel.ErrorMessage = "Пароли обязаны соответствовать";
                    break;
                case RegistrationResult.EmailAlreadyExists:
                    _registerViewModel.ErrorMessage = "Аккаунт с заданным email уже существует";
                    break;
                case RegistrationResult.UsernameAlreadyExists:
                    _registerViewModel.ErrorMessage = "Аккаунт с заданным логином уже существует";
                    break;
                default:
                    _registerViewModel.ErrorMessage = "Ошибка регистрации";
                    break;
            }
        }
    }
}
