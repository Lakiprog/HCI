using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.ViewModels
{
    class InvitesViewModel : ObservableObject
    {
        public InvitesViewModel()
        {
            InitData();
            InitCommands();
        }

        private Invites invites;

        public Invites Invites
        {
            get => invites;
            set { invites = value; RaisePropertyChngedEvent("Invites"); }
        }

        private void InitCommands()
        {
        }
        private void InitData()
        {
            addPlacholderData();
        }

        private void addPlacholderData()
        {
            this.invites = new Invites() { AllInvites = new List<string>(), TaskId = 0 };
            invites.AllInvites.Add("Joe");
            invites.AllInvites.Add("Thomas");
            invites.AllInvites.Add("Isaiah");
            invites.AllInvites.Add("Matthew");
            invites.AllInvites.Add("Sean");
        }
    }
}
