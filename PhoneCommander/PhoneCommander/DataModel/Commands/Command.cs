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

        public void MarkRead()
        {
            this.DateRead = DateTime.Now;
        }
    }
}
