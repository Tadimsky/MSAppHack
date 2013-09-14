using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Newtonsoft.Json;
using phoneApp;

namespace PhoneCommander.DataModel.Commands
{
    public class Command
    {

        public int Id { get; set; }
        
        public String UserId { get; set; }

        public String FromDevice { get; set; }

        public String ToDevice { get; set; }

        public DateTime DateSent { get; set; }

        public DateTime DateRead { get; set; }

        public String Number { get; set; }
        
        public String Text { get; set; }
        
        public String Address { get; set; }

        public Command()
        {
            
            DateSent = DateTime.Now;
            if (App.Settings.Device != null)
            {
                FromDevice = App.Settings.Device.UniqueId;
            }
            else
            {
                FromDevice = "";
            }
            ToDevice = "";
            Number = "";
            Text = "";
            Address = "";
        }

        public void MarkRead()
        {
            this.DateRead = DateTime.Now;
        }

        public bool IsCall
        {
            get
            {
                return !String.IsNullOrEmpty(Number) && String.IsNullOrEmpty(Text);
            }
        }

        public bool IsText
        {
            get
            {
                return !String.IsNullOrEmpty(Number) && !String.IsNullOrEmpty(Text);
            }
        }

        public bool IsAddress
        {
            get
            {
                return !String.IsNullOrEmpty(Address) && String.IsNullOrEmpty(Text);
            }
        }
    }
}
