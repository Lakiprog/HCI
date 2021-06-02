using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.ViewModels
{
    public class EventDetailsViewModel : ObservableObject
    {
        private Event _EventDetails;
        public EventDetailsViewModel(Event eventDetails) {
            EventDetails = eventDetails;
        }

        public Event EventDetails
        {
            get => _EventDetails;
            set { _EventDetails = value; RaisePropertyChngedEvent("EventDetails"); }
        }
    }
}
