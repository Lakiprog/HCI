using EventPlanner.Commands;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    class OrganizerViewModel : ObservableObject
    {
        public OrganizerViewModel(Organizer o)
        {
            organizer = o;
            temp = new Organizer(o.Username, o.Password, o.FirstName, o.LastName);
            InitCommands();
        }

        private Organizer organizer;
        private Organizer temp;
        private void InitCommands()
        {
            SaveCommand = new EditOrganizerCommand(this);
        }

        public Organizer Temp
        {
            get => temp;
        }

        public Organizer Organizer
        {
            get => organizer;
        }

        public void saveChanges()
        {
            organizer.FirstName = temp.FirstName;
            organizer.LastName = temp.LastName;
            organizer.Password = temp.Password;
            organizer.Username = temp.Username;
        }

        public ICommand SaveCommand
        {
            get;
            private set;
        }

    }
}
