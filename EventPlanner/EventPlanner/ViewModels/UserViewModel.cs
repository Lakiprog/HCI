using EventPlanner.Commands;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    class UserViewModel : ObservableObject
    {
        private User user;
        public bool isOrganizer;
        public bool canUpdate;

        public UserViewModel()
        {
            InitData();
            InitCommands();
            InitChildViewModels();
        }

        private void InitData()
        {
            // getting logged-in user
            user = new Organizer("micko", "micko123", "Mica", "Lakic", 3);
            user.Messages.Add(new Message("Hey, where are you?", 2, DateTime.Now, false));
            user.Messages.Add(new Message("Hey, hello?", 2, DateTime.Now, true));
            user.Messages.Add(new Message("I've almost finished this event", 3, DateTime.Now, false));
            user.Messages.Add(new Message("Hope you're doing ok", 4, DateTime.Now, false));
            user.Messages.Add(new Message("I saw you the other day.", 1, DateTime.Now, true));
            isOrganizer = true;
            canUpdate = false;
        }
        public ICommand EditUserCmd
        {
            get; private set;
        }
        private void InitCommands()
        {
            EditUserCmd = new EditUserCommand(this);
        }
        private void InitChildViewModels()
        {
            UserMessagesViewModel = new UserMessagesViewModel(User);
        }
        public User User
        {
            get => user;
            set { user = value; RaisePropertyChngedEvent("User"); }
        }

        public bool IsOrganizer
        {
            get => isOrganizer;
            set { isOrganizer = value; RaisePropertyChngedEvent("IsOrganizer"); }
        }
        public bool CanUpdate
        {
            get => canUpdate;
            set { canUpdate = value; RaisePropertyChngedEvent("CanUpdate"); }
        }
        public UserMessagesViewModel UserMessagesViewModel
        {
            get => userMessagesViewModel;
            set { userMessagesViewModel = value; RaisePropertyChngedEvent("UserMessagesViewModel"); }
        }

        private UserMessagesViewModel userMessagesViewModel;
        public void SaveChanges()
        {
            Debug.Assert(false, String.Format("{0} is username.", User.Username));
            // Successfully got modified data (stored in User)
            CanUpdate = false;
        }
    }
}
