using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.Domain.Models;
using ToDo.Domain.Services;
using ToDo.EntityFramework;
using ToDo.WPF.Commands;
using ToDo.WPF.State.Accounts;
using ToDo.WPF.State.Common;

namespace ToDo.WPF.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly IAccountStore _accountStore;
        private readonly IGenericStore<User> _userStore;
        private readonly IAccountService _accountService;

        private List<User> _users;
        public List<User> Users
        {
            get
            {
                if(currentUser.Role == "Administrator")
                {
                    return _users;
                }
                return null;
            }
            set
            {
                if (currentUser.Role == "Administrator")
                {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }

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

        private string previousPassword;
        public string PreviousPassword
        {
            get
            {
                return previousPassword;
            }
            set
            {
                previousPassword = value;
                OnPropertyChanged(nameof(PreviousPassword));
            }
        }

        private string updatedPassword;
        public string UpdatedPassword
        {
            get
            {
                return updatedPassword;
            }
            set
            {
                updatedPassword = value;
                OnPropertyChanged(nameof(UpdatedPassword));
            }
        }

        private string confirmationPassword;
        public string ConfirmationPassword
        {
            get
            {
                return confirmationPassword;
            }
            set
            {
                confirmationPassword = value;
                OnPropertyChanged(nameof(ConfirmationPassword));
            }
        }
        public ICommand UpdateAccountCommand { get; }
        public ICommand UpdateAllAccountsCommand { get; }
        public ICommand ChangePasswordCommand { get; }
        public MessageViewModel ResultMessageViewModel { get; }
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ResultMessage { set => ResultMessageViewModel.Message = value; }
        public string ErrorMessage { set => ErrorMessageViewModel.Message = value; }

        public AccountViewModel(IAccountStore accountStore, IAccountService accountService, MessageViewModel resultMessageViewModel, MessageViewModel errorMessageViewModel)
        {
            _accountStore = accountStore;
            CurrentUser = accountStore.CurrentAccount;
            _accountService = accountService;
            UpdateAccountCommand = new UpdateAccountCommand(this, accountService);
            UpdateAllAccountsCommand = new UpdateAllAccountsCommand(this, accountService);
            ChangePasswordCommand = new ChangePasswordCommand(accountService, this, new PasswordHasher());
            ResultMessageViewModel = new MessageViewModel();
            ErrorMessageViewModel = new MessageViewModel();
            ResultMessage = string.Empty;
            ErrorMessage = string.Empty;
            _userStore = new GenericStore<User>(_accountService);
            _userStore.LoadWithJoin(item => item.Username == item.Username);
            Users = _userStore.Domains;
        }
    }
}
