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
    class OrganizersViewModel : ObservableObject
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
        public ICommand FilterOrganizersCmd
        {
            get;
            private set;
        }

        public OrganizersViewModel()
        {
            InitData();
            InitCommands();
        }

        public void FilterOrganizers(string search)
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
            FilterOrganizersCmd = new FilterOrganizersCommand(this);
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
                new Organizer("jim.halpert", "pam", "Jim", "Halpert", 3),
                new Organizer("dwight.schrute", "beets", "Dwight", "Schrute", 4),
                new Organizer("pam.beesley", "pan", "Pam", "Beesley", 5),
                new Organizer("kevin.malone", "123", "Kevim", "Malone", 1),
                new Organizer("erin.hannon", "dunder", "Erin", "Hannon", 2)
            };

            organizers.ForEach(this.organizers.Add);
        }
    }
}
