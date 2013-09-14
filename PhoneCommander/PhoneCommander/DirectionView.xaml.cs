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
    public sealed partial class DirectionView : UserControl
    {   public DirectionView()
        {
            this.InitializeComponent();
        }

        private async void CallButton_Click(object sender, RoutedEventArgs e)
        {
            progrBar.Visibility = Visibility.Visible;
            Command t = new Command();
            t.Address = txtAddress.Text;
            await App.MobileService.GetTable<Command>().InsertAsync(t);
            progrBar.Visibility = Visibility.Collapsed;
        }
    }
}
