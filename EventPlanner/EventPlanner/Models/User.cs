using EventPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.Models
{
    public class User : ObservableObject
    {
        private string username;
        private string password;
        private string firstName;
        private string lastName;
        public String Username  {
            get => username;
            set { username = value; RaisePropertyChngedEvent("Username"); }
        }
        public String Password  { 
            get => password;
            set { password = value; RaisePropertyChngedEvent("Password"); } 
        }
        public String FirstName { 
            get => firstName;
            set { firstName = value; RaisePropertyChngedEvent("FirstName"); }
        }
        public String LastName  { 
            get => lastName;
            set { lastName = value; RaisePropertyChngedEvent("LastName"); } 
        }

        public User(string username, string password, string firstName, string lastName)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
