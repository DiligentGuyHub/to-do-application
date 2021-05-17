using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WPF.State.Navigators;

namespace ToDo.WPF.ViewModels.Factories
{
    public interface IToDoViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
