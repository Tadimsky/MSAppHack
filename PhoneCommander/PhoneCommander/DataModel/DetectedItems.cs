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

        private bool loadingAddresses;

        public bool LoadingAddresses
        {
            get
            {
                return loadingAddresses;
            }
            set
            {
                loadingAddresses = value;
                OnPropertyChanged("LoadingAddresses");
            }
        }

        private bool loadingNumbers;

        public bool LoadingNumbers
        {
            get
            {
                return loadingNumbers;
            }
            set
            {
                loadingNumbers = value;
                OnPropertyChanged("LoadingNumbers");
            }
        }

        public DetectedItems()
        {
            Numbers = new ObservableCollection<String>();
            Addresses = new ObservableCollection<String>();

            LoadingAddresses = true;
            LoadingNumbers = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
