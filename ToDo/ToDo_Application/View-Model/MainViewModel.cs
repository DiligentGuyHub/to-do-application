using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ToDo_Application.Utilities;
using ToDo_Application.View;

namespace ToDo_Application.View_Model
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Task> Tasks { get; set; }
        public UserControl ActivePage { get; set; }

        public MainViewModel()
        {
            Tasks = new ObservableCollection<Task>();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private int _Clicks;
        public int Clicks
        {
            get { return _Clicks; }
            set
            {
                _Clicks = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ClickAdd
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    Clicks++;
                }, (obj) => Clicks < 10);
            }
        }

    }
}
