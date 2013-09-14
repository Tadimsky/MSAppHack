using System.Threading.Tasks;
using Windows.UI.Popups;
using PhoneCommander.Classes;
using PhoneCommander.Common;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using Windows.System.Profile;
// The Split App template is documented at http://go.microsoft.com/fwlink/?LinkId=234228
using PhoneCommander.DataModel;

namespace PhoneCommander
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {   
        public static StorageManager Settings;


        /// <summary>
        /// Initializes the singleton Application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            App.Settings = new StorageManager();
            
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active

            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                //Associate the frame with a SuspensionManager key                                
                SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Restore the saved session state only when appropriate
                    try
                    {
                        await SuspensionManager.RestoreAsync();
                    }
                    catch (SuspensionManagerException)
                    {
                        //Something went wrong restoring state.
                        //Assume there is no state and continue
                    }
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }
            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof (ItemsPage), "AllGroups"))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();

            await loadData();
        }


        private async Task loadData()
        {
            await Authenticate();
            await LoadDevice();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }

        public static MobileServiceClient MobileService = new MobileServiceClient(
            "https://contineo.azure-mobile.net/",
            "dKkpkjGXSnvcEQLaHnyXpuiRrFzPuS21"
            );

        /// <summary>
        /// Invoked when the application is activated as the target of a sharing operation.
        /// </summary>
        /// <param name="args">Details about the activation request.</param>
        protected async override void OnShareTargetActivated(
            Windows.ApplicationModel.Activation.ShareTargetActivatedEventArgs args)
        {
            var shareTargetPage = new PhoneCommander.SharePage();
            shareTargetPage.Activate(args);
            await loadData();
        }

        private async Task Authenticate()
        {
            while (Settings.User == null)
            {
                string message;
                try
                {
                    Settings.User = await App.MobileService.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount);
                    message = string.Format("You are now logged in!");
                }
                catch (InvalidOperationException)
                {
                    message = "You must login.";
                }

                var dialog = new MessageDialog(message);
                dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
            }
        }

        private async Task LoadDevice()
        {
            var items = await App.MobileService.GetTable<Devices>().Where(todoItem => todoItem.UniqueId == GetHardwareId() && todoItem.User == Settings.User.UserId).ToCollectionAsync();

            foreach (var item in items)
            {
                Settings.Device = item.UniqueId;
            }
            if (String.IsNullOrEmpty(Settings.Device)) 
            {
                Devices d = new Devices();
                d.User = Settings.User.UserId;
                d.UniqueId = GetHardwareId();
                var k = Windows.Networking.Connectivity.NetworkInformation.GetHostNames();
                if (k != null)
                {
                    d.Name = k[0].DisplayName;
                }
                await App.MobileService.GetTable<Devices>().InsertAsync(d);
                Settings.Device = d.UniqueId;
            }
            
        }

        protected async override void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);
            await Authenticate();

        }

        public static string GetHardwareId()
        {
            var token = HardwareIdentification.GetPackageSpecificToken(null);
            var hardwareId = token.Id;
            var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(hardwareId);

            byte[] bytes = new byte[hardwareId.Length];
            dataReader.ReadBytes(bytes);

            return BitConverter.ToString(bytes);
        }  

        public static int DeviceId { get; set; }
    }
}
    