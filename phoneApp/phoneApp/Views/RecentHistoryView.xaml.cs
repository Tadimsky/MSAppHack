using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneCommander.DataModel.Commands;
using phoneApp.ViewModels;
using System.Collections.ObjectModel;

namespace phoneApp.Views
{
    public partial class RecentHistoryView : UserControl
    {
        public RecentHistoryView()
        {
            InitializeComponent();
            DataContext = new phoneApp.ViewModels.CommandViewModel();
        }

        private void change(object sender, RoutedEventArgs e)
        {
            if (sender is LongListSelector)
            {
                Command sel = (Command) (((LongListSelector)sender).SelectedItem);
                if (sel is DirectionCommand || sel is AddressCommand)
                {
                    App.OpenMaps(((AddressCommand)sel).address);
                }
                else if(sel is CallCommand)
                {
                    App.makeCall(((CallCommand)sel).Number, ((CallCommand)sel).DisplayName);
                }
            }
        }
        
    }
}
