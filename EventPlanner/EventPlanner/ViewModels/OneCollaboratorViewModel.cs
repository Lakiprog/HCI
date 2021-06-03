using EventPlanner.Commands;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{

    class OneCollaboratorViewModel : ObservableObject
    {
        public OneCollaboratorViewModel(Collaborator c)
        {
            collaborator = c;
            InitCommands();
        }

        private Collaborator collaborator;
        private void InitCommands()
        {
            //UpdateListCommand = new SearchCollaboratorsCommand(this);
            //CreateEditWindowCmd = new CreateEditWindowsCommand();
        }

        public Collaborator Collaborator
        {
            get => collaborator;
        }




    }
}
