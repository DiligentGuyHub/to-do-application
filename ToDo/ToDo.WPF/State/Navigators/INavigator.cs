using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.WPF.Commands;
using ToDo.WPF.ViewModels;

namespace ToDo.WPF.State.Navigators
{
    public enum ViewType
    {
        Login,
        Register,
        Account,
        Settings,
        Task,
        Home,
        Today
    }
    public interface INavigator
    {
        public ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}
