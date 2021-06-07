using EventPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.Models
{
    public enum TaskStatus { TO_DO, IN_PROGRESS, DONE }
    public enum TaskType { GENERIC, SEATING }
    public class Task : ObservableObject
    {
        private int _Id;
        private string _Title;
        private TaskStatus _Status;
        private int _EventId;
        private string _Description;
        private Collaborator _Collaborator;
        private TaskType _Type;

        public int Id
        {
            get => _Id;
            set { _Id = value; RaisePropertyChngedEvent("Id"); }
        }
        public String Title
        {
            get => _Title;
            set { _Title = value; RaisePropertyChngedEvent("Title"); }
        }
        public TaskStatus Status
        {
            get => _Status;
            set { _Status = value; RaisePropertyChngedEvent("Status"); }
        }
        public int EventId
        {
            get => _EventId;
            set { _EventId = value; RaisePropertyChngedEvent("EventId"); }
        }
        public String Description
        {
            get => _Description;
            set { _Description = value; RaisePropertyChngedEvent("Description"); }
        }
        public Collaborator Collaborator
        {
            get => _Collaborator;
            set { _Collaborator = value; RaisePropertyChngedEvent("Collaborator"); }
        }
        public TaskType Type
        {
            get => _Type;
            set { _Type = value; RaisePropertyChngedEvent("Type"); }
        }
        public Task(string title, TaskStatus status, int eventId, string description, Collaborator collaborator, TaskType type)
        {
            Title = title;
            Status = status;
            EventId = eventId;
            Description = description;
            Collaborator = collaborator;
            Type = type;
        }
        public Task() { }
    }
}
