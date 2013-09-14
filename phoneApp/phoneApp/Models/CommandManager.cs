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
            commands.Add(new Command() { Id = 1 });
            commands.Add(new Command() { Id = 2 });
            commands.Add(new Command() { Id = 3 });
            commands.Add(new CallCommand() { Id = 10, DisplayName = "Call" });
            commands.Add(new CallCommand() { Id = 10, DisplayName = "Call2" });
            commands.Add(new CallCommand() { Id = 10, DisplayName = "Cal1" });
            commands.Add(new TextCommand() { Id = 7, UserId = 12874 });
            commands.Add(new DirectionCommand() { Id = 10,  address = "Bangalore" });
            commands.Add(new DirectionCommand() { Id = 10, address= "Romania" });

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
            return commands;
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
    }
}
