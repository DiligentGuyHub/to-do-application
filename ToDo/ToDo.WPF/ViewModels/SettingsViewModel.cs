using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.WPF.Commands;
using ToDo.WPF.State.Settings;

namespace ToDo.WPF.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public ICommand UpdateCurrentThemeCommand { get; }
        public SettingsViewModel(ISettings settings)
        {
            UpdateCurrentThemeCommand = new UpdateCurrentThemeCommand(settings, this);
        }

    }
}
