﻿using EventPlanner.Models;
using EventPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.Commands
{
    class RemoveTableCommand : ICommand
    {
        public RemoveTableCommand(SeatingPlanViewModel viewModel)
        {
            _ViewModel = viewModel;
        }
        private SeatingPlanViewModel _ViewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            foreach(string invitation in ((TableViewModel)parameter).Table.Invites)
            {
                _ViewModel.Invitations.Add(invitation);
            }
            _ViewModel.Tables.Remove((TableViewModel)parameter);
        }
    }
}
