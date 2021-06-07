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
        public OrganizerViewModel(Organizer o, bool hasRepeat)
        {
            organizer = o;
            temp = new Organizer(o.ID, o.Username, o.Password, o.FirstName, o.LastName, o.Rating);
            repeat = new Organizer(0, "", o.Password, "", "", 0);
            repeatPassword = hasRepeat;
            InitCommands();
        }

        private Organizer organizer;
        private Organizer temp;
        private Organizer repeat;
        private bool repeatPassword;

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

        public Organizer Repeat
        {
            get => repeat;
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

        public bool CanUpdate
        {
            get
            {
                if (Temp == null)
                {
                    return false;
                }
                if (String.IsNullOrWhiteSpace(Temp.FirstName))
                {
                    return false;
                }
                else if (String.IsNullOrWhiteSpace(Temp.LastName))
                {
                    return false;
                }
                else if (String.IsNullOrWhiteSpace(Temp.Password))
                {
                    return false;
                }
                else if (String.IsNullOrWhiteSpace(Temp.Username))
                {
                    return false;
                }if(repeatPassword && (repeat.Password != temp.Password))
                {
                    return false;
                }
                return true;
            }
        }
    }
}
