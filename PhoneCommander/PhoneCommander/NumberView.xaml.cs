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

namespace PhoneCommander
{
    public sealed partial class NumberView : UserControl
    {   public NumberView()
        {
            this.InitializeComponent();
        }

        private async void TextButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtTextContent.Visibility == Visibility.Collapsed)
            {
                txtTextContent.Visibility = Visibility.Visible;
            }
            else
            {
                Command t = new Command();
                t.Text = txtTextContent.Text;
                t.Number = txtNumber.Text;
                await App.MobileService.GetTable<Command>().InsertAsync(t);

                txtTextContent.Visibility = Visibility.Collapsed;
            }
        }

        private void CallButton_Click(object sender, RoutedEventArgs e)
        {
            // send phone call
        }
    }
}
