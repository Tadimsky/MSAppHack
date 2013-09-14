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
        public ObservableCollection<Command> Commands { get; set; }
        public ObservableCollection<Command> Numbers { get; set; }
        public ObservableCollection<Command> Addresses { get; set; }


        public CommandManager()
        {
            this.Commands = new ObservableCollection<Command>();
            this.Numbers = new ObservableCollection<Command>();
            this.Addresses = new ObservableCollection<Command>();
            InitializeCommands();
        }

        private async void InitializeCommands()
        {
            List<Command> f = await App.MobileService.GetTable<Command>().ToListAsync();
            foreach (var j in f)
            {
                Commands.Add(j);
                if (j.IsAddress)
                {
                    Addresses.Add(j);
                }
                else
                {
                    Numbers.Add(j);
                }
            }
        }
    }
}
