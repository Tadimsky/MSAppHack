using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phoneApp;

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

        public String Number { get; set; }

        public String Text { get; set; }

        public String Address { get; set; }

        public Command()
        {
            DateSent = DateTime.Now;
            FromDevice = -1;
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
