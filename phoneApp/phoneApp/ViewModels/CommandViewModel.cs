using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phoneApp.Resources;
using PhoneCommander.DataModel.Commands;
using System.Collections.ObjectModel;
using phoneApp.Models;

namespace phoneApp.ViewModels
{
    //generic view model to show the list of commands 
    public class CommandViewModel
    {   
    
        public ObservableCollection<Command> Commands {get;set;}
        public ObservableCollection<Command> Directions
        {
            get
            {
                return App.Commands.Directions();
            }
            
        }
        public ObservableCollection<Command> Numbers
        {
            get
            {
                return App.Commands.Numbers();
            }

        }

        public CommandViewModel()
        {

            App.Commands = new CommandManager();

            this.Commands = App.Commands.Commands();
        }
        
    }

    
}
