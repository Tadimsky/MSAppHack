using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Notification;


namespace phoneApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        HttpNotificationChannel pushChannel;

        string channelName = "pushChannel"; //CHANGE LATER
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DataContext = App.ViewModel;

            pushChannel = HttpNotificationChannel.Find(channelName);
            // Set the data context of the listbox control to the sample data
            // If the channel was not found, then create a new connection to the push service.
            if (pushChannel == null)
            {
                pushChannel = new HttpNotificationChannel(channelName);

                // Register for all the events before attempting to open the channel.
                pushChannel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(PushChannel_ChannelUriUpdated);
 
                pushChannel.Open();

            }
            else
            {
                // The channel was already open, so just register for all the events.
                pushChannel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(PushChannel_ChannelUriUpdated);

                // Display the URI for testing purposes. Normally, the URI would be passed back to your web service at this point.
                System.Diagnostics.Debug.WriteLine(pushChannel.ChannelUri.ToString());
                MessageBox.Show(String.Format("Channel Uri is {0}",
                    pushChannel.ChannelUri.ToString()));

            }

            
        }

        //push nofiticaion retceived
        void PushChannel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {

            Dispatcher.BeginInvoke(() =>
            {
                // Display the new URI for testing purposes. Normally, the URI would be passed back to your web service at this point.
                System.Diagnostics.Debug.WriteLine(e.ChannelUri.ToString());
                MessageBox.Show(String.Format("Channel Uri is {0}",
                    e.ChannelUri.ToString()));

            });
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
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