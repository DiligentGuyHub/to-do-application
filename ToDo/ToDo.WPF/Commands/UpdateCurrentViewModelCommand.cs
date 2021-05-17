using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.WPF.State.Navigators;
using ToDo.WPF.ViewModels.Factories;

namespace ToDo.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : AsyncCommandBase
    {
        private readonly INavigator _navigator;
        private readonly IToDoViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IToDoViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is ViewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel((ViewType)parameter);
            }
        }
    }
}
