using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WPF.ViewModels.Factories
{
    public interface ToDoViewModelFactory2<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
