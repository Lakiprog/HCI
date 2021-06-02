using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EventPlanner.ViewModels
{
    class NotificationsViewModel : ObservableObject
    {
        private List<NotificationViewModel> _NotificationViewModels;

        public NotificationsViewModel()
        {
            InitData();
        }

        private void InitData()
        {
            _NotificationViewModels = new List<NotificationViewModel>();
            AddOriginalData();
        }
        private void AddOriginalData()
        {
            // Load user notifications
            User u1 = new User("micko","micko123","Mica","Lakic");
            User u2 = new User("stefan", "stefan123", "Stefan", "Stefan");
            
            _NotificationViewModels.Add(new NotificationViewModel(new Notification(u1, new NotificationElement(), NotificationType.MESSAGE_SENT)));
            _NotificationViewModels.Add(new NotificationViewModel(new Notification(u1, new NotificationElement(), NotificationType.EVENT_REQUEST)));
            _NotificationViewModels.Add(new NotificationViewModel(new Notification(u2, new NotificationElement(), NotificationType.EVENT_REQUEST)));
        }
        
        public List<NotificationViewModel> NotificationViewModels
        {
            get => _NotificationViewModels;
            set { _NotificationViewModels = value; RaisePropertyChngedEvent("NotificationViewModels"); }
        }
    }
}
