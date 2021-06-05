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
            temp = new Collaborator(c.Name, c.Type, c.Address);
            InitCommands();
        }

        private Collaborator collaborator;
        private Collaborator temp;
        private void InitCommands()
        {
            SaveCommand = new EditCollaboratorCommand(this);
        }

        public Collaborator Temp
        {
            get => temp;
        }

        public Collaborator Collaborator
        {
            get => collaborator;
        }

        public void saveChanges()
        {
            collaborator.Name = temp.Name;
            collaborator.Type = temp.Type;
            collaborator.Address = temp.Address;
        }

        public ICommand SaveCommand
        {
            get;
            private set;
        }
    }
}
