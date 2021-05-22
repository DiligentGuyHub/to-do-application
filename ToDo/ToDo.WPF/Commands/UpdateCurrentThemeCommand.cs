using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToDo.WPF.State.Settings;
using ToDo.WPF.ViewModels;
using ToDo.WPF.ViewModels.Factories;

namespace ToDo.WPF.Commands
{
    public class UpdateCurrentThemeCommand : AsyncCommandBase
    {
        private readonly ISettings _settings;
        private readonly SettingsViewModel _settingsViewModel;

        public UpdateCurrentThemeCommand(ISettings settings, SettingsViewModel settingsViewModel)
        {
            _settings = settings;
            _settingsViewModel = settingsViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            App.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(
                Application.LoadComponent(new Uri($"/Styles/{parameter.ToString()}.xaml", UriKind.Relative)) as ResourceDictionary
                );
            Application.Current.Resources.MergedDictionaries.Add(
               Application.LoadComponent(new Uri($"/Styles/NavigationBar.xaml", UriKind.Relative)) as ResourceDictionary
               );
            Application.Current.Resources.MergedDictionaries.Add(
               Application.LoadComponent(new Uri($"/Styles/Settings.xaml", UriKind.Relative)) as ResourceDictionary
               );
            //switch (parameter.ToString())
            //{
            //    case "Classic":
            //        Application.Current.Resources.MergedDictionaries.Add(
            //            Application.LoadComponent(new Uri("<materialDesign:BundledThemeBaseTheme = \"Light\" PrimaryColor = \"#006b70\" SecondaryColor = \"#00adb5\" /> ")) as ResourceDictionary
            //        );
            //        break;
            //    case "Reddish":
            //        Application.Current.Resources.MergedDictionaries.Add(
            //            Application.LoadComponent(new Uri("<materialDesign:BundledThemeBaseTheme = \"Light\" PrimaryColor = \"#810000\" SecondaryColor = \"#ce1212\" /> ")) as ResourceDictionary
            //        );
            //        break;
            //    case "PinkyPie":
            //        Application.Current.Resources.MergedDictionaries.Add(
            //            Application.LoadComponent(new Uri("<materialDesign:BundledThemeBaseTheme = \"Light\" PrimaryColor = \"#e93b81\" SecondaryColor = \"#f5abc9\" /> ")) as ResourceDictionary
            //        );
            //        break;
            //}

        }
    }
}
