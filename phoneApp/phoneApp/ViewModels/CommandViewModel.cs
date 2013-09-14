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
    public class CommandViewModel {
    
        public ObservableCollection<Command> Commands {get;set;}
        public ObservableCollection<DirectionCommand> Directions
        {
            get
            {
                return App.CommandManager.Directions();
            }
            
        }
        public ObservableCollection<CallCommand> Numbers
        {
            get
            {
                return App.CommandManager.Numbers();
            }

        }

        public CommandViewModel()
        {

            this.Commands = App.CommandManager.Commands();
        }
        
    }

    
}
