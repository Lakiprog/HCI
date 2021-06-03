using EventPlanner.Commands;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    class OneOrganizerViewModel : ObservableObject
    {
        public OneOrganizerViewModel(Organizer o)
        {
            organizer = o;
            InitCommands();
        }

        private Organizer organizer;
        private void InitCommands()
        {
            //UpdateListCommand = new SearchCollaboratorsCommand(this);
            //CreateEditWindowCmd = new CreateEditWindowsCommand();
        }

        public Organizer Organizer
        {
            get => organizer;
        }



    }
}
