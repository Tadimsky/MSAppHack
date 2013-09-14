using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Microsoft.WindowsAzure.MobileServices;

namespace PhoneCommander.Classes
{
    
    public class StorageManager
    {
        private ApplicationDataContainer localSettings;


        private MobileServiceUser user; 
        public MobileServiceUser User
        {
            get
            {
                return user; //(MobileServiceUser)localSettings.Values["userAuth"];
            }
            set
            {
                user = value;  // localSettings.Values["userAuth"] = value;
            }
        }

        public String Device { get; set; }

        public StorageManager()
        {
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        }

    }
}
