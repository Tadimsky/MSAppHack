using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using phoneApp.ViewModels;

namespace phoneApp.Views
{
    public partial class NumbersView : UserControl
    {
        public NumbersView()
        {
            InitializeComponent();
            DataContext = new CommandViewModel();
        }
        private void call(object sender, RoutedEventArgs e)
        {
            if (sender is RecentHistoryView)
            {
                //((RecentHistoryView)sender).GetValue();
            }
        }
    }
}
