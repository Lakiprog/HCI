using EventPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.Models
{
    public enum NotificationType { MESSAGE_SENT, EVENT_REQUEST, EVENT_CHANGED }
    public class Notification : ObservableObject
    {
        private long _Id;
        private User _UserFrom;
        private User _UserTo;
        private NotificationElement _NotificationElement;
        private NotificationType _Type;

        public long Id
        {
            get => _Id;
            set { _Id = value; RaisePropertyChngedEvent("Id"); }
        }
        public User UserFrom
        {
            get => _UserFrom;
            set { _UserFrom = value; RaisePropertyChngedEvent("UserFrom"); }
        }
        public User UserTo
        {
            get => _UserTo;
            set { _UserTo = value; RaisePropertyChngedEvent("UserTo"); }
        }
        public NotificationElement NotificationElement
        {
            get => _NotificationElement;
            set { _NotificationElement = value; RaisePropertyChngedEvent("NotificationElement"); }
        }
        public NotificationType Type
        {
            get => _Type;
            set { _Type = value; RaisePropertyChngedEvent("Type"); }
        }
        public Notification(long id, User user, NotificationElement notificationelement, NotificationType type)
        {
            Id = id;
            UserFrom = user;
            NotificationElement = notificationelement;
            Type = type;
        }
        public String Description
        {
            get
            {
                if (_Type == NotificationType.MESSAGE_SENT) return _UserFrom.Username + " sent you a message";
                else if (_Type == NotificationType.EVENT_REQUEST) return _UserFrom.Username + " requested you to organize his/hers event.";
                else return _UserFrom.Username + " changed information about the event.";
            }
        }
        
    }
}
