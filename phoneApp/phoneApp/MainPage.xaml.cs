﻿using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using phoneApp.Models;

namespace phoneApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
        }

        // Load data for the ViewModel Items
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            App.Commands = new CommandManager();
            await App.Authenticate();
            await App.LoadDevice();
            App.Settings.Device.PushChannel = App.CurrentChannel.ToString();
            await App.MobileService.GetTable<Devices>().UpdateAsync(App.Settings.Device);
        }

        private void LongListSelector_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //do something here when you click on something
        }

        private void Directions_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}