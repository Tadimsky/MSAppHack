using PhoneCommander.DataModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoneApp.ViewModels
{
    public class AddressCommand : Command
    {
        public string address { get; set; }
    }
}
