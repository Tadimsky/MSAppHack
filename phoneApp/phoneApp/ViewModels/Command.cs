using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCommander.DataModel.Commands
{
    public class Command
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int FromDevice { get; set; }
        public int ToDevice { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime DateRead { get; set; }

        public void MarkRead()
        {
            this.DateRead = DateTime.Now;
        }
    }
}
