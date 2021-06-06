using EventPlanner.Commands;
using EventPlanner.Models;
using EventPlanner.Services;
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
        }

        private void InitData()
        {
            // getting logged-in user
            user = UserService.Singleton().CurrentUser;
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
        public void SaveChanges()
        {
            Debug.Assert(false, String.Format("{0} is username.", User.Username));
            // Successfully got modified data (stored in User)
            CanUpdate = false;
        }
    }
}
