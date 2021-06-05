using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using EventPlanner.Commands;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    class UserMessagesViewModel : ObservableObject
    {
        public ObservableCollection<MessagesViewModel> MessagesViewModels
        {
            get => messagesViewModels;
        }
        public MessagesViewModel SelectedViewModel
        {
            get => selectedViewModel;
            set { selectedViewModel = value; RaisePropertyChngedEvent("SelectedViewModel"); }
        }
        public ICommand SelectUsersMessageCmd
        {
            get; private set;
        }

        public UserMessagesViewModel(User user)
        {
            InitData(user);
            InitCommands();
        }

        private void InitData(User user)
        {
            messagesViewModels = new ObservableCollection<MessagesViewModel>();

            var results = from m in user.Messages
                          orderby m.TimeStamp ascending
                          group m by m.SenderId into n
                          select new { SenderId = n.Key, Messages = n.ToList() };

            results.ToList().ForEach(senderMessages =>
            {
                messagesViewModels.Add(new MessagesViewModel(senderMessages.Messages, "Hernos"));
            });

            if (messagesViewModels.Count > 0)
            {
                SelectedViewModel = messagesViewModels[0];
            }
        }

        private void InitCommands()
        {
            SelectUsersMessageCmd = new SelectUsersMessageCommand(this);
        }

        private ObservableCollection<MessagesViewModel> messagesViewModels;
        private MessagesViewModel selectedViewModel;
    }
}
