using EventPlanner.Commands;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    class NotificationsViewModel : ObservableObject
    {
        private ObservableCollection<Notification> _Notifications;

        public NotificationsViewModel()
        {
            InitData();
            InitCommands();
        }

        private void InitData()
        {
            _Notifications = new ObservableCollection<Notification>();
            AddOriginalData();
        }
        private void InitCommands()
        {
            DeleteNotificationCmd = new DeleteNotificationCommand(this);
        }
        private void AddOriginalData()
        {
            // Load user notifications
            User u1 = new User(1,"micko","micko123","Mica","Lakic");
            User u2 = new User(2,"stefan", "stefan123", "Stefan", "Stefan");

            List<Notification> notifications = new List<Notification>();
            notifications.Add(new Notification(1, u1, new NotificationElement(), NotificationType.MESSAGE_SENT));
            notifications.Add(new Notification(2, u1, new NotificationElement(), NotificationType.EVENT_REQUEST));
            notifications.Add(new Notification(3, u2, new NotificationElement(), NotificationType.EVENT_REQUEST));
            notifications.ForEach(_Notifications.Add);
        }
        
        public ObservableCollection<Notification> Notifications
        {
            get => _Notifications;
            set { _Notifications = value; RaisePropertyChngedEvent("NotificationViewModels"); }
        }
        public ICommand DeleteNotificationCmd
        {
            get; private set;
        }
       
        public void DeleteNotification(Notification notification)
        {
            _Notifications.Remove(notification);
        }
    }
}
