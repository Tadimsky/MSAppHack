using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoneCommander.DataModel.Commands
{
    class TextCommand : Command
    {
        [JsonProperty(PropertyName = "numbers")]
        public List<String>  Numbers { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
