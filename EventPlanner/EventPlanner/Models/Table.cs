using EventPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EventPlanner.Models
{
    public class Table : ObservableObject
    {
        private string _Name;
        private ObservableCollection<string> _Invites;

        public String Name
        {
            get => _Name;
            set { _Name = value; RaisePropertyChngedEvent("Name"); }
        }
        public ObservableCollection<string> Invites
        {
            get => _Invites;
            set { _Invites = value; RaisePropertyChngedEvent("Invites"); }
        }

        public Table(string name, ObservableCollection<string> invites)
        {
            Name = name;
            Invites = invites;
        }
    }
}
