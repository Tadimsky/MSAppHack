using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
// The Share Target Contract item template is documented at http://go.microsoft.com/fwlink/?LinkId=234241
using PhoneCommander.Classes;
using PhoneCommander.DataModel;
using PhoneCommander.DataModel.Commands;

namespace PhoneCommander
{
    /// <summary>
    /// This page allows other applications to share content through this application.
    /// </summary>
    public sealed partial class SharePage : PhoneCommander.Common.LayoutAwarePage
    {


        public static Devices SendTo;
        /// <summary>
        /// Provides a channel to communicate with Windows about the sharing operation.
        /// </summary>
        private Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation _shareOperation;

        public SharePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when another application wants to share content through this application.
        /// </summary>
        /// <param name="args">Activation data used to coordinate the process with Windows.</param>
        public async void Activate(ShareTargetActivatedEventArgs args)
        {
            this._shareOperation = args.ShareOperation;
            

            // Communicate metadata about the shared content through the view model
            var shareProperties = this._shareOperation.Data.Properties;
            var thumbnailImage = new BitmapImage();
            this.DefaultViewModel["Title"] = shareProperties.Title;
            this.DefaultViewModel["Description"] = shareProperties.Description;
            this.DefaultViewModel["Image"] = thumbnailImage;
            this.DefaultViewModel["Sharing"] = false;
            this.DefaultViewModel["ShowImage"] = false;
            this.DefaultViewModel["Comment"] = String.Empty;
            this.DefaultViewModel["SupportsComment"] = true;
            Window.Current.Content = this;
            Window.Current.Activate();

            Detector dt = new Detector(_shareOperation.Data);
            dt.Detect();
            this.DataContext = dt.Detected;

            // Update the shared content's thumbnail image in the background
            if (shareProperties.Thumbnail != null)
            {
                var stream = await shareProperties.Thumbnail.OpenReadAsync();
                thumbnailImage.SetSource(stream);
                this.DefaultViewModel["ShowImage"] = true;
            }
        }

        /// <summary>
        /// Invoked when the user clicks the Share button.
        /// </summary>
        /// <param name="sender">Instance of Button used to initiate sharing.</param>
        /// <param name="e">Event data describing how the button was clicked.</param>
        private void ShareButton_Click(object sender, RoutedEventArgs e)
        {
            this.DefaultViewModel["Sharing"] = true;
            this._shareOperation.ReportStarted();

            // TODO: Perform work appropriate to your sharing scenario using
            //       this._shareOperation.Data, typically with additional information captured
            //       through custom user interface elements added to this page such as 
            //       this.DefaultViewModel["Comment"]

            this._shareOperation.ReportCompleted();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var f = e.AddedItems;
            if (f.Count > 0)
            {
                SendTo = (Devices)f[0];
            }
        }
    }
}
