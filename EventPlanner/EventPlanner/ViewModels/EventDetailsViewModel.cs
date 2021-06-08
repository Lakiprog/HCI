using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.ViewModels
{
    public class EventDetailsViewModel : ObservableObject
    {
        private Event _EventDetails;
        private bool _IsFree;
        private bool _IsOrganizersEvent;

        public EventDetailsViewModel(Event eventDetails, bool isFree, bool isOrganizersEvent) {
            EventDetails = eventDetails;
            IsFree = isFree;
            IsOrganizersEvent = isOrganizersEvent;
        }

        public Event EventDetails
        {
            get => _EventDetails;
            set { _EventDetails = value; RaisePropertyChngedEvent("EventDetails"); }
        }
        public bool IsFree
        {
            get => _IsFree;
            set { _IsFree = value; RaisePropertyChngedEvent("IsFree"); }
        }
        public bool IsOrganizersEvent
        {
            get => _IsOrganizersEvent;
            set { _IsOrganizersEvent = value; RaisePropertyChngedEvent("IsOrganizersEvent"); }
        }
    }
}
