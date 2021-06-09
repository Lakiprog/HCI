using EventPlanner.Models;
using EventPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.Commands
{
    class OpenViewItemModalCommand : ICommand
    {
        public OpenViewItemModalCommand() { }

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
            if(parameter is Task)
            {
                if(((Task)parameter).Type == TaskType.GENERIC)
                {
                    var taskModal = new Modals.TaskModal();
                    taskModal.DataContext = new TaskViewModel((Task)parameter);
                    taskModal.Show();
                } else
                {
                    var taskModal = new Modals.SeatingPlanModal();
                    taskModal.DataContext = new SeatingPlanViewModel(((Task)parameter).Id);
                    taskModal.Show();
                }
                
            } else if (parameter is Event)
            {
                var eventDetailsModal = new Modals.EventDetailsModal();
                eventDetailsModal.DataContext = new ViewModels.EventDetailsViewModel((Event)parameter, false, false);
                eventDetailsModal.Show();
            }
        }
    }
}
