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
        private void InitializeCommands() 
        {
            commands.Add(new Command() { Address = "duke University", Id = 10, UserId = 281 });
            commands.Add(new Command() { Address = "vancouver", Id = 11, UserId = 81 });
            commands.Add(new Command() { Number="901928", Id = 12, UserId = 21, Text="dinner here?" });
            commands.Add(new Command() { Number = "901928", Id = 21, UserId = 218, Text = "dinner there?" });
            commands.Add(new Command() { Number = "901928", Id = 121, UserId = 218 });
            commands.Add(new Command() { Address = "Local Yogurt", Id = 33, UserId = 284 });
            commands.Add(new Command() { Address = "Middle Earth", Id = 23, UserId = 24 });
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
