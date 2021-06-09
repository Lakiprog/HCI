using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlanner.ViewModels
{
    public class TableViewModel : ObservableObject
    {
        private Table _Table;
        public TableViewModel(Table table)
        {
            Table = table;
        }
        public Table Table
        {
            get => _Table;
            set { _Table = value; RaisePropertyChngedEvent("Table"); }
        }
    }
}
