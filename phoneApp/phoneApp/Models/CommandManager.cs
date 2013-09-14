using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PhoneCommander.DataModel.Commands;
using System.Threading;
using System.Windows;
using phoneApp.ViewModels;

namespace phoneApp.Models
{
    //should have a list of each different type of command

    public class CommandManager
    {
        private ObservableCollection<Command> commands { get; set; }

        public CommandManager()
        {
            this.commands = new ObservableCollection<Command>();
            InitializeCommands();
        }
        private async void InitializeCommands()
        {
            List<Command> f = await App.MobileService.GetTable<Command>().ToListAsync();
            foreach (var j in f)
            {
                commands.Add(j);
            }
        }

        public ObservableCollection<Command> Commands()
        {
            return new ObservableCollection<Command>(commands.OrderByDescending(Command => -Command.Id));
        }
        public ObservableCollection<Command> Directions()
        {
            ObservableCollection<Command> directions = new ObservableCollection<Command>();
            
            foreach (Command c in commands)
            {
                if(c.IsAddress)  
                {
                    directions.Add(c);
                }
            }
            return directions;
        }
        public ObservableCollection<Command> Numbers()
        {
            ObservableCollection<Command> numbers = new ObservableCollection<Command>();

            foreach (Command c in commands)
            {
                if (c.IsCall || c.IsText)
                {
                    numbers.Add(c);
                }
            }
            return numbers;
        }
    }
}
