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
    class CollaboratorViewModel : ObservableObject, ISearchable
    {
        public CollaboratorViewModel()
        {
            InitData();
            InitCommands();
        }
        private ObservableCollection<Collaborator> collaborators;
        private void InitCommands()
        {
            SearchCmd = new SearchCommand(this);
            CreateEditWindowCmd = new CreateEditWindowsCommand();
            CreateAddWindowCmd = new CreateAddWindowsCommand();
        }
        private void InitData()
        {
            collaborators = new ObservableCollection<Collaborator>();
            AddOriginalData();
        }
        private void AddOriginalData()
        {
            this.collaborators.Clear();
            List<Collaborator> collaborators = new List<Collaborator>();
            collaborators.Add(new Collaborator("Zikina klopa", CollaboratorType.RESTAURANT, "Adresa 1"));
            collaborators.Add(new Collaborator("Marinini baloni", CollaboratorType.BALLOONS, "Adresa 2"));
            collaborators.Add(new Collaborator("Pice kod Mice", CollaboratorType.DRINK_STORE, "Adresa 3"));
            collaborators.Add(new Collaborator("Pice kod Mice", CollaboratorType.DRINK_STORE, "Adresa 3"));

            collaborators.ForEach(this.collaborators.Add);
        }

        public ObservableCollection<Collaborator> Collaborators
        {
            get => collaborators;
        }

        public ICommand SearchCmd
        {
            get;
            private set;
        }

        public ICommand CreateEditWindowCmd
        {
            get;
            private set;
        }

        public ICommand CreateAddWindowCmd
        {
            get;
            private set;
        }

        public void Search(string search)
        {
            AddOriginalData();
            if (search.Length > 0)
            {
                List<Collaborator> collaborators = new List<Collaborator>(Collaborators);
                this.collaborators.Clear();
                collaborators.FindAll(collaborator =>
                    collaborator.Name.Contains(search)
                    || collaborator.Address.Contains(search)
                ).ForEach(this.collaborators.Add);
            }
        }
    }
}
