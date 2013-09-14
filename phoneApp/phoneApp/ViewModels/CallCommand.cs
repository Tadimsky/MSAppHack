using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCommander.DataModel.Commands
{
    public class CallCommand : Command
    {
        public string Number { get; set; }
        public string DisplayName { get; set; }
    }
}
