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
            commands.Add(new CallCommand() { Id = 1, DisplayName = "Pooface", Number="9196381191" });
            commands.Add(new CallCommand() { Id = 2, DisplayName = "Call2", Number = "9196381191" });
            commands.Add(new CallCommand() { Id = 3, DisplayName = "Cal1", Number = "9196381191" });
            commands.Add(new DirectionCommand() { Id = 5,  address = "Duke University" });
            commands.Add(new DirectionCommand() { Id = 6, address= "Seoul Korea" });

            /*
            Thread t = new Thread( new ThreadStart(
                this.add
                ));
            t.Start();
            */

        }

        private void add()
        {
            /*
            while (true)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    this.commands.Add(new Command() { Id = 7 });
                });
                Thread.Sleep(500);
            }
            */
        }

        public ObservableCollection<Command> Commands()
        {
            return new ObservableCollection<Command>(commands.OrderByDescending(Command => Command.Id));
        }
        public ObservableCollection<DirectionCommand> Directions()
        {
            ObservableCollection<DirectionCommand> directions = new ObservableCollection<DirectionCommand>();
            
            foreach (Command c in commands)
            {
                if(c is DirectionCommand)  
                {
                    directions.Add((DirectionCommand)c);
                }
            }
            return directions;
        }
        public ObservableCollection<CallCommand> Numbers()
        {
            ObservableCollection<CallCommand> numbers = new ObservableCollection<CallCommand>();

            foreach (Command c in commands)
            {
                if (c is CallCommand)
                {
                    numbers.Add((CallCommand)c);
                }
            }
            return numbers;
        }
    }
}
