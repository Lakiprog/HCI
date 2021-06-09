using EventPlanner.Commands;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    public class SeatingPlanViewModel : ObservableObject
    {
        private SeatingPlan _SeatingPlan;
        private ObservableCollection<TableViewModel> _Tables;
        private ObservableCollection<string> _Invitations;
        public SeatingPlanViewModel(int taskId)
        {
            _Tables = new ObservableCollection<TableViewModel>();
            _Invitations = new ObservableCollection<string>();
            InitData(taskId);
            InitCommands();
        }

        public SeatingPlan SeatingPlan
        {
            get => _SeatingPlan;
            set { _SeatingPlan = value; RaisePropertyChngedEvent("SeatingPlan"); }
        }
        public ObservableCollection<TableViewModel> Tables
        {
            get => _Tables;
            set { _Tables = value; RaisePropertyChngedEvent("Tables"); }
        }
        public ObservableCollection<string> Invitations
        {
            get => _Invitations;
            set { _Invitations = value; RaisePropertyChngedEvent("Invitations"); }
        }
        public ICommand AddTableCmd
        {
            get; private set;
        }
        public ICommand RemoveTableCmd
        {
            get; private set;
        }
        private void InitCommands()
        {
            AddTableCmd = new AddTableCommand(this);
            RemoveTableCmd = new RemoveTableCommand(this);
        }
        private void InitData(int taskId)
        {
            Table t1 = new Table("table 1", new ObservableCollection<string> {"pera peric", "mika mikic", "seka sekic" });
            Table t2 = new Table("table 2", new ObservableCollection<string> { "saska", "zoki", "steki" });
            Table t3 = new Table("table 3", new ObservableCollection<string> { "pani", "veverica", "slon" });
            List<Table> tables = new List<Table>();
            tables.Add(t1); tables.Add(t2); tables.Add(t3);
            
            // get SeatingPlan from database by taskId
            SeatingPlan seatingPlan = new SeatingPlan(1, tables, taskId);

            foreach(Table table in seatingPlan.Tables)
            {
                _Tables.Add(new TableViewModel(table));
            }
            _Invitations.Add("invitation 1");
            _Invitations.Add("invitation 2");
            _Invitations.Add("invitation 3");
        }

    }
}
