using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using PhoneCommander.DataModel;
using PhoneCommander.DataModel.Commands;
using Windows.UI.Popups;

namespace PhoneCommander
{
    public sealed partial class NumberView : UserControl
    {   public NumberView()
        {
            this.InitializeComponent();
        }

        private async void TextButton_Click(object sender, RoutedEventArgs e)
        {
            if (SharePage.SendTo == null)
            {
                MessageDialog mb = new MessageDialog("Please select a device to send to.");
                mb.ShowAsync();
                return;
            }
            if (txtTextContent.Visibility == Visibility.Collapsed)
            {
                txtTextContent.Visibility = Visibility.Visible;
            }
            else
            {
                progrBar.Visibility = Visibility.Visible;
                Command t = new Command();
                t.Text = txtTextContent.Text;
                t.Number = txtNumber.Text;
                await App.MobileService.GetTable<Command>().InsertAsync(t);

                txtTextContent.Visibility = Visibility.Collapsed;
                progrBar.Visibility = Visibility.Collapsed;
            }
        }

        private async void CallButton_Click(object sender, RoutedEventArgs e)
        {
            if (SharePage.SendTo == null)
            {
                MessageDialog mb = new MessageDialog("Please select a device to send to.");
                mb.ShowAsync();
                return;
            }
            progrBar.Visibility = Visibility.Visible;
            Command t = new Command();
            t.Number = txtNumber.Text;
            await App.MobileService.GetTable<Command>().InsertAsync(t);
            progrBar.Visibility = Visibility.Collapsed;
        }
    }
}
