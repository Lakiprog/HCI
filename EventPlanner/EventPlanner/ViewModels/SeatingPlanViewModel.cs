using EventPlanner.Commands;
using EventPlanner.Models;
using EventPlanner.Services;
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
        private string _NewTableName;
        bool firstCreation;
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
        public String NewTableName
        {
            get => _NewTableName;
            set { _NewTableName = value; RaisePropertyChngedEvent("NewTableName"); }
        }
        public ICommand AddTableCmd
        {
            get; private set;
        }
        public ICommand RemoveTableCmd
        {
            get; private set;
        }
        public ICommand SaveSeatingPlanCmd
        {
            get; private set;
        }
        private void InitCommands()
        {
            AddTableCmd = new AddTableCommand(this);
            RemoveTableCmd = new RemoveTableCommand(this);
            SaveSeatingPlanCmd = new SaveSeatingPlanCommand(this);
        }
        private void InitData(int taskId)
        {
            _Tables.Clear(); _Invitations.Clear();
            //Table t1 = new Table("table 1", new List<string> { "pera peric", "mika mikic", "seka sekic" });
            //Table t2 = new Table("table 2", new List<string> { "saska", "zoki", "steki" });
            //Table t3 = new Table("table 3", new List<string> { "pani", "veverica", "slon" });

            //List<Table> tables = new List<Table>();
            //tables.Add(t1); tables.Add(t2); tables.Add(t3);

            //get SeatingPlan from database by taskId
            //SeatingPlan seatingPlan = new SeatingPlan(1, tables, taskId);
            List<TableViewModel> tableViewModels = new List<TableViewModel>();
            _SeatingPlan = SeatingPlanService.Singleton().GetseatingPlanByTask(taskId);
            
            if(_SeatingPlan == null)
            {
                firstCreation = true;
                _SeatingPlan = new SeatingPlan(SeatingPlanService.Singleton().GetLastId(),
                    new List<Table>(), taskId, new List<string>());
            }
            else
            {
                firstCreation = false;
                foreach (Table table in _SeatingPlan.Tables)
                {
                    tableViewModels.Add(new TableViewModel(table));
                }
                tableViewModels.ForEach(_Tables.Add);
                List<string> invitations = _SeatingPlan.UnsortedGuests;
                invitations.ForEach(_Invitations.Add);
            }
        }
        public bool CanUpdate()
        {
            if (String.IsNullOrWhiteSpace(_NewTableName)) return false;
            return true;
        }
        public void AddTable()
        {
            _Tables.Add(new TableViewModel(new Table(_NewTableName, new List<string>())));
        }
        public void SaveSeatingPlan()
        {
            _SeatingPlan.Tables.Clear();
            foreach (TableViewModel viewModel in _Tables)
            {
                _SeatingPlan.Tables.Add(new Table(viewModel.Name, new List<string>(viewModel.Invites)));
            }
            // save seating plan to file
            if (firstCreation)
            {
                SeatingPlanService.Singleton().Add(_SeatingPlan);
                firstCreation = false;
            }
            else
            {
                SeatingPlanService.Singleton().Modify(_SeatingPlan);
            }
        }
    }
}
