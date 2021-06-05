using EventPlanner.Commands;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    class MessagesViewModel : ObservableObject
    {
        public ObservableCollection<Message> Messages
        {
            get => messages;
        }
        public string SenderName
        {
            get => senderName;
            set { senderName = value; RaisePropertyChngedEvent("SenderName"); }
        }
        public string CurrentMessage {
            get => currentMessage;
            set { currentMessage = value; RaisePropertyChngedEvent("CurrentMessage"); }
        }
        public ICommand SendMessageCmd
        {
            get;
            private set;
        }

        public MessagesViewModel(List<Message> messages, string senderName)
        {
            this.messages = new ObservableCollection<Message>();
            messages.ForEach(this.messages.Add);
            this.senderName = senderName;
            SendMessageCmd = new SendMessageCommand(this);
        }
        public void SendMessage(string messageContents)
        {
            Message message = new Message(messageContents, 1, DateTime.Now, true);
            messages.Add(message);
            // Service call to save message to db here
            CurrentMessage = string.Empty;
        }

        private ObservableCollection<Message> messages;
        private string senderName;
        private string currentMessage;
    }
}
