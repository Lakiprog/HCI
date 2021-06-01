﻿using EventPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.Commands
{
    internal class SearchCollaboratorsCommand : ICommand
    {
        public SearchCollaboratorsCommand(CollaboratorViewModel viewModel)
        {
            _ViewModel = viewModel;
        }
        private CollaboratorViewModel _ViewModel;

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
            _ViewModel.SearchCollaborators((string)parameter);
        }
    }
}
