using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDo.Domain.Models;
using ToDo.Domain.Services;
using ToDo.WPF.ViewModels;
using Task = System.Threading.Tasks.Task;

namespace ToDo.WPF.Commands
{
    public class ChangePasswordCommand : AsyncCommandBase
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly AccountViewModel _accountViewModel;

        public ChangePasswordCommand(IAccountService accountService, AccountViewModel accountViewModel, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _accountViewModel = accountViewModel;
            _passwordHasher = passwordHasher;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            _accountViewModel.ResultMessage = string.Empty;
            _accountViewModel.ErrorMessage = string.Empty;
            PasswordVerificationResult passwordVerificationResult = _passwordHasher.VerifyHashedPassword(_accountViewModel.CurrentUser.PasswordHash, _accountViewModel.PreviousPassword);
            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                _accountViewModel.ResultMessage = string.Empty;
                _accountViewModel.ErrorMessage = "Previous password is incorrect";
                return;
            }
            if(_accountViewModel.UpdatedPassword != _accountViewModel.ConfirmationPassword)
            {
                _accountViewModel.ResultMessage = string.Empty;
                _accountViewModel.ErrorMessage = "Confirmation password must match updated password";
                return;
            }
            _accountViewModel.CurrentUser.PasswordHash =  _passwordHasher.HashPassword(_accountViewModel.UpdatedPassword);
            
            await _accountService.Update(_accountViewModel.CurrentUser.Id, _accountViewModel.CurrentUser);
            _accountViewModel.ResultMessage = "Account password updated successfully.";
            _accountViewModel.ErrorMessage = string.Empty;

        }
    }
}
