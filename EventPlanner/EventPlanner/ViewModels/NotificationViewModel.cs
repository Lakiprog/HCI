using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.ViewModels
{
    class NotificationViewModel : ObservableObject
    {
        private Notification _Notification;

        public NotificationViewModel(Notification notification)
        {
            Notification = notification;
        }
        public Notification Notification
        {
            get => _Notification;
            set { _Notification = value; RaisePropertyChngedEvent("Notification"); }
        }
        public String Description
        {
            get
            {
                if (_Notification.Type == NotificationType.MESSAGE_SENT) return _Notification.User.Username + " sent you a message";
                else if (_Notification.Type == NotificationType.EVENT_REQUEST) return _Notification.User.Username + " requested you to organize his/hers event.";
                else return _Notification.User.Username + " changed information about the event.";
            }
        }
    }
}
