using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WPF.State.Tasks
{
    public interface ITaskStore
    {
        public ObservableCollection<Domain.Models.Task> Tasks { get; set; }
        event Action StateChanged;
    }
}
