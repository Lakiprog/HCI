﻿using EventPlanner.Commands;
using EventPlanner.Models;
using EventPlanner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    class EventsViewModel : ObservableObject, ISearchable
    {
        public EventsViewModel()
        {
            InitData();
            InitCommands();
        }
        private ObservableCollection<Event> organizerEvents;
        private ObservableCollection<Event> upcomingEvents;
        private ObservableCollection<Event> pastEvents;
        private Event selectedEvent;
        
        public ObservableCollection<Event> OrganizerEvents
        {
            get => organizerEvents;
            set { organizerEvents = value; RaisePropertyChngedEvent("OrganizerEvents"); }
        }
        public ObservableCollection<Event> UpcomingEvents
        {
            get => upcomingEvents;
            set { upcomingEvents = value; RaisePropertyChngedEvent("UpcomingEvents"); }
        }
        public ObservableCollection<Event> PastEvents
        {
            get => pastEvents;
            set { pastEvents = value; RaisePropertyChngedEvent("PastEvents"); }
        }
        public Event SelectedEvent
        {
            get => selectedEvent;
            set { selectedEvent = value; RaisePropertyChngedEvent("SelectedEvent"); }
        }

        public ICommand SearchCmd
        {
            get;
            private set;
        }
        public ICommand ShowEventModalCommand
        {
            get;
            private set;
        }
        public ICommand GoToBoardCmd
        {
            get;
            private set;
        }

        private void InitCommands()
        {
            ShowEventModalCommand = new ShowEventModalCommand();
            SearchCmd = new SearchCommand(this);
            GoToBoardCmd = new GoToBoardCommand();
        }
        private void InitData()
        {
            organizerEvents = new ObservableCollection<Event>();
            upcomingEvents = new ObservableCollection<Event>();
            pastEvents = new ObservableCollection<Event>();
            AddOriginalData();
        }
        private void AddOriginalData()
        {
            this.organizerEvents.Clear();
            List<Event> organizerEvents = new List<Event>();
            User user = UserService.Singleton().CurrentUser;
            organizerEvents.Add(new Event("Resourceful project manager with 10 years of experience", EventType.WEDDING, "desc1", DateTime.ParseExact("2021-06-05 13:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact("2021-06-05 18:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), user));
            organizerEvents.Add(new Event("Engaging high school teacher skilled in ESL and IEPS", EventType.WEDDING, "desc1", DateTime.ParseExact("2021-06-05 13:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact("2021-06-05 18:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), user));
            organizerEvents.Add(new Event("Multi-lingual licensed RN with 5+ years of experience in pediatrics", EventType.WEDDING, "desc1", DateTime.ParseExact("2021-06-05 13:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact("2021-06-05 18:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), user));
            organizerEvents.Add(new Event("Hard-working CNA and Nightingale Award recipient", EventType.WEDDING, "desc1", DateTime.ParseExact("2021-06-05 13:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact("2021-06-05 18:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), user));

            organizerEvents.ForEach(this.organizerEvents.Add);

            this.upcomingEvents.Clear();
            List<Event> upcomingEvents = new List<Event>();
            upcomingEvents.Add(new Event("Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled", EventType.WEDDING, "desc1", DateTime.ParseExact("2021-06-05 13:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact("2021-06-05 18:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), user));
            upcomingEvents.Add(new Event("System.Runtime.Serialization.Formatters.dll", EventType.WEDDING, "desc1", DateTime.ParseExact("2021-06-05 13:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact("2021-06-05 18:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), user));
            upcomingEvents.Add(new Event("EventPlanner.exe", EventType.WEDDING, "desc1", DateTime.ParseExact("2021-06-05 13:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact("2021-06-05 18:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), user));
            upcomingEvents.Add(new Event("Title 24", EventType.WEDDING, "desc1", DateTime.ParseExact("2021-06-05 13:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact("2021-06-05 18:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), user));

            upcomingEvents.ForEach(this.upcomingEvents.Add);


            this.pastEvents.Clear();
            List<Event> pastEvents = new List<Event>();
            pastEvents.Add(new Event("Event 1", EventType.WEDDING, "desc1", DateTime.ParseExact("2021-06-05 13:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact("2021-06-05 18:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), user));
            pastEvents.Add(new Event("Event 2", EventType.WEDDING, "desc1", DateTime.ParseExact("2021-06-05 13:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact("2021-06-05 18:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), user));
            pastEvents.Add(new Event("EventPlanner.exe", EventType.WEDDING, "desc1", DateTime.ParseExact("2021-06-05 13:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact("2021-06-05 18:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), user));
            pastEvents.Add(new Event("Event 24", EventType.WEDDING, "desc1", DateTime.ParseExact("2021-06-05 13:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact("2021-06-05 18:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), user));

            pastEvents.ForEach(this.pastEvents.Add);
        }

        public void Search(string search)
        {
            // TODO: Implement search of events
            throw new NotImplementedException();
        }
    }
}
