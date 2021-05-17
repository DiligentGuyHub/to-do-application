using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDo.WPF.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        //private void SwitchToClassic(object sender, RoutedEventArgs e)
        //{
        //    var uri = new Uri("/Styles/Classic.xaml", UriKind.Relative);
        //    ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
        //    Application.Current.Resources.MergedDictionaries.Clear();
        //    Application.Current.Resources.MergedDictionaries.Add(resource);
        //    Application.Current.Resources.MergedDictionaries.Add(NavigationBar);
        //}
        //private void SwitchToReddish(object sender, RoutedEventArgs e)
        //{
        //    var uri = new Uri("/Styles/Reddish.xaml", UriKind.Relative);
        //    ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
        //    Application.Current.Resources.MergedDictionaries.Clear();
        //    Application.Current.Resources.MergedDictionaries.Add(resource);
        //    Application.Current.Resources.MergedDictionaries.Add(NavigationBar);
        //}
        //private void SwitchToBluish(object sender, RoutedEventArgs e)
        //{
        //    var uri = new Uri("/Styles/Bluish.xaml", UriKind.Relative);
        //    ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
        //    Application.Current.Resources.MergedDictionaries.Clear();
        //    Application.Current.Resources.MergedDictionaries.Add(resource);
        //    Application.Current.Resources.MergedDictionaries.Add(NavigationBar);
        //}
    }
}
