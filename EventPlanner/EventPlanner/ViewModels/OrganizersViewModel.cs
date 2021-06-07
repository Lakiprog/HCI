using EventPlanner.Commands;
using EventPlanner.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    class OrganizersViewModel : ObservableObject, ISearchable
    {
        /// <summary>
        /// Gets the Organizer Collection instance
        /// </summary>
        public ObservableCollection<Organizer> Organizers
        {
            get => organizers;
        }

        /// <summary>
        /// Gets the FilterOrganizersCommand for the ViewModel
        /// </summary>
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

        public OrganizersViewModel()
        {
            InitData();
            InitCommands();
        }

        public void Search(string search)
        {
            AddOriginalData();
            if (search.Length > 0)
            {
                List<Organizer> organizers = new List<Organizer>(Organizers);
                this.organizers.Clear();
                organizers.FindAll(organizer =>
                    organizer.FirstName.Contains(search)
                    || organizer.LastName.Contains(search)
                    || organizer.Username.Contains(search)
                ).ForEach(this.organizers.Add);
            }
        }

        private void InitCommands()
        {
            SearchCmd = new SearchCommand(this);
            FilterOrganizersCmd = new FilterOrganizersCommand(this);
            CreateEditWindowCmd = new CreateEditWindowsCommand();
            CreateAddWindowCmd = new CreateAddWindowsCommand();
        }

        private ObservableCollection<Organizer> organizers;

        private void InitData()
        {
            organizers = new ObservableCollection<Organizer>();
            AddOriginalData();
        }

        private void AddOriginalData()
        {
            this.organizers.Clear();
            // Call to a service function will return a list of organizers that need to be added here
            List<Organizer> organizers = new List<Organizer>() {
                new Organizer(1,"jim.halpert", "pam", "Jim", "Halpert", 3),
                new Organizer(2,"dwight.schrute", "beets", "Dwight", "Schrute", 4),
                new Organizer(3,"pam.beesley", "pan", "Pam", "Beesley", 5),
                new Organizer(4,"kevin.malone", "123", "Kevim", "Malone", 1),
                new Organizer(5,"erin.hannon", "dunder", "Erin", "Hannon", 2)
            };

            organizers.ForEach(this.organizers.Add);
        }
    }
}
