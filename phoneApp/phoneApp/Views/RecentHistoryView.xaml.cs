using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace phoneApp.Views
{
    public partial class RecentHistoryView : UserControl
    {
        public RecentHistoryView()
        {
            InitializeComponent();
            DataContext = new phoneApp.ViewModels.CommandViewModel();
        }
    }
}
