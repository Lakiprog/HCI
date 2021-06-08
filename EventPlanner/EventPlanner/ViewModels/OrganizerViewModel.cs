using EventPlanner.Commands;
using EventPlanner.Models;
using EventPlanner.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
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

        public OrganizerViewModel(Organizer o, bool hasRepeat, OrganizersViewModel model)
        {
            organizer = o;
            temp = new Organizer(o.ID, o.Username, o.Password, o.FirstName, o.LastName, o.Rating);
            repeat = new Organizer(0, "", o.Password, "", "", 0);
            repeatPassword = hasRepeat;
            parent = model;
            InitCommands();
        }

        private Organizer organizer;
        private Organizer temp;
        private Organizer repeat;
        private bool repeatPassword;
        private OrganizersViewModel parent;

        private void InitCommands()
        {
            SaveCommand = new EditOrganizerCommand(this);
            DeleteCommand = new DeleteOrganizerCommand(this);
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
            bool add = false;
            if (organizer.FirstName == "")
            {
                UserService.Singleton().Add(temp);
                add = true;
            }
            else
            {
                UserService.Singleton().Modify(temp);
            }

            organizer.FirstName = temp.FirstName;
            organizer.LastName = temp.LastName;
            organizer.Password = temp.Password;
            organizer.Username = temp.Username;

            if (add)
            {
                parent.Organizers.Add(organizer);
            }
        }

        public void delete()
        {
            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult rsltMessageBox = MessageBox.Show("Are you sure you wish to delete this organizer permanently?",
                "Event Planner", btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    UserService service = UserService.Singleton();
                    service.Delete(organizer);
                    parent.Organizers.Clear();
                    List<Organizer> organizers = service.GetOrganizers();
                    organizers.ForEach(parent.Organizers.Add);

                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item.DataContext == this) item.Close();
                    }

                    break;

                case MessageBoxResult.No:
                    /* ... */
                    break;
            }
        }

        public ICommand SaveCommand
        {
            get;
            private set;
        }

        public ICommand DeleteCommand
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
