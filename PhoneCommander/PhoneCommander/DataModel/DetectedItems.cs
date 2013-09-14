using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneCommander.DataModel.Commands;

namespace PhoneCommander.DataModel
{
    public class DetectedItems : INotifyPropertyChanged
    {
        public ObservableCollection<String> Numbers { get; set; }
        public ObservableCollection<String> Addresses { get; set; }

        public DetectedItems()
        {
            Numbers = new ObservableCollection<String>();
            Addresses = new ObservableCollection<String>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
