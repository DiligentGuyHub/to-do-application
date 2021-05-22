using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.WPF.ViewModels;

namespace ToDo.WPF.Commands
{
    public class UpdateAccountCommand : AsyncCommandBase
    {
        private readonly IAccountService _accountService;
        private readonly AccountViewModel _accountViewModel;
        public UpdateAccountCommand(AccountViewModel accountViewModel, IAccountService accountService)
        {
            _accountService = accountService;
            _accountViewModel = accountViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _accountViewModel.ResultMessage = string.Empty;
            _accountViewModel.ErrorMessage = string.Empty;

            try
            {
                await _accountService.Update(_accountViewModel.CurrentUser.Id, _accountViewModel.CurrentUser);
                _accountViewModel.ResultMessage = "Account information updated successfully.";
                _accountViewModel.ErrorMessage = string.Empty;
            }
            catch (Exception)
            {
                _accountViewModel.ErrorMessage = "Account information wasn't updated.";
                _accountViewModel.ResultMessage = string.Empty;

            }
        }
    }
}
