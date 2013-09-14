using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoneCommander.DataModel.Commands
{
    public class Command
    {

        public int Id { get; set; }

        [JsonProperty(PropertyName = "userid")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "fromdevice")]
        public int FromDevice { get; set; }

        [JsonProperty(PropertyName = "todevice")]
        public int ToDevice { get; set; }

        [JsonProperty(PropertyName = "datesent")]
        public DateTime DateSent { get; set; }

        [JsonProperty(PropertyName = "dateread")]
        public DateTime DateRead { get; set; }

        [JsonProperty(PropertyName = "number")]
        public String Number { get; set; }

        [JsonProperty(PropertyName = "text")]
        public String Text { get; set; }

        [JsonProperty(PropertyName = "address")]
        public String Address { get; set; }

        public Command()
        {
            DateSent = DateTime.Now;
            FromDevice = App.DeviceId;
            ToDevice = -1;
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
