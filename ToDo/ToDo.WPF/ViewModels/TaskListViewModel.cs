using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WPF.State.Tasks;

namespace ToDo.WPF.ViewModels
{
    public class TaskListViewModel : ViewModelBase
    {
        //private ObservableCollection<Domain.Models.Task> tasks;
        //public ObservableCollection<Domain.Models.Task> Tasks
        //{
        //    get
        //    {
        //        return tasks;
        //    }
        //    set
        //    {
        //        tasks = value;
        //        OnPropertyChanged(nameof(Tasks));
        //    }
        //}

        public TaskStore _taskStore;

    }
}
