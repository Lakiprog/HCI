using EventPlanner.Commands;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    internal class CollaboratorViewModel : INotifyPropertyChanged
    {
        public CollaboratorViewModel()
        {
            List<Collaborator> collaborators = new List<Collaborator>();
            collaborators.Add(new Collaborator("Zikina klopa", CollaboratorType.RESTAURANT, "Adresa 1"));
            collaborators.Add(new Collaborator("Marinini baloni", CollaboratorType.BALLOONS, "Adresa 2"));
            collaborators.Add(new Collaborator("Pice kod Mice", CollaboratorType.DRINK_STORE, "Adresa 3"));
            collaborators.Add(new Collaborator("Pice kod Mice", CollaboratorType.DRINK_STORE, "Adresa 3"));
            _Collaborators = new ObservableCollection<Collaborator>(collaborators);

            UpdateListCommand = new CollaboratorListUpdateCommand(this);
        }
        public bool CanUpdate
        {
            get
            {
                return true;
            }
        }

        private ObservableCollection<Collaborator> _Collaborators;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Collaborator> Collaborators
        {
            get
            {
                return _Collaborators;
            }
            set
            {
                _Collaborators = value;
                OnPropertyChanged("_Collaborators");
            }
        }

        public ICommand UpdateListCommand
        {
            get;
            private set;
        }

        public void SaveChanges()
        {
            _Collaborators.RemoveAt(0); //proba
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
