using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCommander.DataModel.Commands
{
    class TextCommand : Command
    {
        public List<String>  Numbers { get; set; }
        public string Text { get; set; }
    }
}
