using EventPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.Models
{
    class SeatingPlan : ObservableObject
    {
        private List<Table> _Tables;

        public List<Table> Tables
        {
            get => _Tables;
            set { _Tables = value; RaisePropertyChngedEvent("Tables"); }
        }
    }
}
