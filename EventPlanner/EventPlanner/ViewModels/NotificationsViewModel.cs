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
        private ObservableCollection<NotificationViewModel> _NotificationViewModels;

        public NotificationsViewModel()
        {
            InitData();
            InitCommands();
        }

        private void InitData()
        {
            _NotificationViewModels = new ObservableCollection<NotificationViewModel>();
            AddOriginalData();
        }
        private void InitCommands()
        {
            DeleteNotificationCmd = new DeleteNotificationCommand(this);
        }
        private void AddOriginalData()
        {
            // Load user notifications
            User u1 = new User("micko","micko123","Mica","Lakic");
            User u2 = new User("stefan", "stefan123", "Stefan", "Stefan");

            List<NotificationViewModel> notificationViewModels = new List<NotificationViewModel>();
            notificationViewModels.Add(new NotificationViewModel(new Notification(1, u1, new NotificationElement(), NotificationType.MESSAGE_SENT)));
            notificationViewModels.Add(new NotificationViewModel(new Notification(2, u1, new NotificationElement(), NotificationType.EVENT_REQUEST)));
            notificationViewModels.Add(new NotificationViewModel(new Notification(3, u2, new NotificationElement(), NotificationType.EVENT_REQUEST)));
            notificationViewModels.ForEach(_NotificationViewModels.Add);
        }
        
        public ObservableCollection<NotificationViewModel> NotificationViewModels
        {
            get => _NotificationViewModels;
            set { _NotificationViewModels = value; RaisePropertyChngedEvent("NotificationViewModels"); }
        }
        public ICommand DeleteNotificationCmd
        {
            get; private set;
        }
        public void DeleteNotification(Notification notification)
        {
            foreach (NotificationViewModel viewModel in _NotificationViewModels)
            {
                if(viewModel.Notification == notification)
                {
                    _NotificationViewModels.Remove(viewModel);
                    return;
                }
            }
        }
    }
}
