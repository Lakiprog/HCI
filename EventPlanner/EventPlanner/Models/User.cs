using EventPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.Models
{
    public class User : ObservableObject
    {
        private int id;
        private string username;
        private string password;
        private string firstName;
        private string lastName;
        private List<Conversation> conversations;
        public int ID
        {
            get => id;
        }
        public String Username
        {
            get => username;
            set { username = value; RaisePropertyChngedEvent("Username"); }
        }
        public String Password
        {
            get => password;
            set { password = value; RaisePropertyChngedEvent("Password"); }
        }
        public String FirstName
        {
            get => firstName;
            set { firstName = value; RaisePropertyChngedEvent("FirstName"); }
        }
        public String LastName
        {
            get => lastName;
            set { lastName = value; RaisePropertyChngedEvent("LastName"); }
        }
        public List<Conversation> Conversations
        {
            get => conversations;
            set { conversations = value; RaisePropertyChngedEvent("Conversations"); }
        }

        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public User(int id, string username, string password, string firstName, string lastName)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            conversations = new List<Conversation>();
        }
    }
}
