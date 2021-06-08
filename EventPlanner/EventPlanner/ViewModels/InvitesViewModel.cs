using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private SeatingPlan seatingPlan;

        public Invites Invites
        {
            get => invites;
            set { invites = value; RaisePropertyChngedEvent("Invites"); }
        }

        public SeatingPlan SeatingPlan
        {
            get => seatingPlan;
            set { seatingPlan = value; RaisePropertyChngedEvent("SeatingPlan"); }
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
