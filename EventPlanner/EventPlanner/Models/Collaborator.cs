using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EventPlanner.Models
{
    public enum CollaboratorType { FLOWER_SHOP, RESTAURANT, BALLOONS, DRINK_STORE }
    public class Collaborator : INotifyPropertyChanged
    {
        private string _Name;
        private string _Address;
        private CollaboratorType _Type;

        public event PropertyChangedEventHandler PropertyChanged;

        public String Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        public String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
                OnPropertyChanged("Address");
            }
        }

        public CollaboratorType Type {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
                OnPropertyChanged("Type");
            }
        }

        public Collaborator(string name, CollaboratorType type, string address)
        {
            Name = name;
            Type = type;
            Address = address;
        }

        public Collaborator() { }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
