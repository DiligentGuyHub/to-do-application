﻿    using System;
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

namespace ToDo.WPF.Controls
{
    /// <summary>
    /// Interaction logic for TaskDescription.xaml
    /// </summary>
    public partial class TaskDescription : UserControl
    {
        public TaskDescription()
        {
            InitializeComponent();
        }

        //private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        //{
        //    ScrollViewer scrollviewer = sender as ScrollViewer;
        //    if (e.Delta > 0)
        //        scrollviewer.LineLeft();
        //    else
        //        scrollviewer.LineRight();
        //    e.Handled = true;
        //}
    }
}
