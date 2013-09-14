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
using PhoneCommander.DataModel.Commands;

namespace phoneApp.Views
{
    public partial class DirectionsView : UserControl
    {
        public DirectionsView()
        {
            InitializeComponent();

            //DataContext = App.Commands;
        }
        private void getDirections(object sender, RoutedEventArgs e)
        {
            Command sel = (Command)(((LongListSelector)sender).SelectedItem);

            if (sel.IsAddress)
            {
                App.OpenMaps(sel.Address);
            }
        }
    }
}
