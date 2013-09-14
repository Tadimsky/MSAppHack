using PhoneCommander.DataModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace phoneApp
{
    public class CommandTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Direction { get; set; }
        public DataTemplate Call { get; set; }
        public DataTemplate Text { get; set; }
        public DataTemplate Address { get; set; }

        /*
        protected override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Command command = item as Command;
            if (command != null)
            {
                var path = command.type.Split('.');
                var name = path[path.Length-1];

                if (name.Equals("DirectionCommand"))
                {
                    return Direction;
                }
                else if (name.Equals("Call"))
                {
                    return Call;
                }
                else if (name.Equals("Text"))
                {
                    return Text;
                }
                else
                {
                    return Address;
                }
            }

            return base.SelectTemplate(item, container);
        }
        */

    }
}
