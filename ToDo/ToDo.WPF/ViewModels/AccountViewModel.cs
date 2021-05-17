using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.Domain.Models;
using ToDo.Domain.Services;
using ToDo.WPF.Commands;
using ToDo.WPF.State.Accounts;

namespace ToDo.WPF.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly IAccountStore _accountStore;
        private readonly IAccountService _accountService;

        private User currentUser;
        public User CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        public ICommand UpdateAccountCommand { get; }
        public MessageViewModel ResultMessageViewModel { get; }

        public string ResultMessage { set => ResultMessageViewModel.Message = value; }

        public AccountViewModel(IAccountStore accountStore, IAccountService accountService, MessageViewModel resultMessageViewModel)
        {
            _accountStore = accountStore;
            CurrentUser = accountStore.CurrentAccount;
            _accountService = accountService;
            UpdateAccountCommand = new UpdateAccountCommand(this, accountService);
            ResultMessageViewModel = resultMessageViewModel;
            ResultMessage = string.Empty;
        }
    }
}
