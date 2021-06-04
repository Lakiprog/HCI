using EventPlanner.Commands;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    class OrganizerViewModel : ObservableObject
    {
        public OrganizerViewModel(Organizer o)
        {
            organizer = o;
            InitCommands();
        }

        private Organizer organizer;
        private void InitCommands()
        {
        }

        public Organizer Organizer
        {
            get => organizer;
        }



    }
}
