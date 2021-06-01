using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.ViewModels
{
    class UserViewModel : ObservableObject
    {
        private User user;
        public bool isOrganizer;

        public UserViewModel()
        {
            InitData();
        }

        private void InitData()
        {
            //user = new User("micko", "micko123", "Mica", "Lakic");
            //isOrganizer = false;

            user = new Organizer("micko", "micko123", "Mica", "Lakic", 3);
            isOrganizer = true;
        }
        public User User
        {
            get => user;
        }

        public bool IsOrganizer
        {
            get => isOrganizer;
            set { isOrganizer = value; RaisePropertyChngedEvent("IsOrganizer"); }
        }
    }
}
