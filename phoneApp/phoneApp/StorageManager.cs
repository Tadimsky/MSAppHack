using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Microsoft.WindowsAzure.MobileServices;

namespace phoneApp

{
    
    public class StorageManager
    {
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

        public Devices Device { get; set; }
    }
}
