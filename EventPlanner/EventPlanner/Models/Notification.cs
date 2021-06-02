using EventPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.Models
{
    public enum NotificationType { MESSAGE_SENT, EVENT_REQUEST, EVENT_CHANGED }
    public class Notification : ObservableObject
    {
        private User _User;
        private NotificationElement _NotificationElement;
        private NotificationType _Type;

        public User User
        {
            get => _User;
            set { _User = value; RaisePropertyChngedEvent("User"); }
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
        public Notification(User user, NotificationElement notificationelement, NotificationType type)
        {
            User = user;
            NotificationElement = notificationelement;
            Type = type;
        }
        
    }
}
