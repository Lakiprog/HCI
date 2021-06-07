using EventPlanner.Commands;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    class TaskViewModel : ObservableObject
    {
        private Task _Task;
        private int _EventId;
        public TaskViewModel(int eventId)
        {
            _Task = new Task();
            _EventId = eventId;
            _Task.Status = TaskStatus.TO_DO;
            InitCommands();
        }
        public TaskViewModel(Task task)
        {
            _Task = task;
            InitCommands();
        }
        public Task Task
        {
            get => _Task;
            set { _Task = value; RaisePropertyChngedEvent("Task"); }
        }
        public int EventId
        {
            get => _EventId;
            set { _EventId = value; RaisePropertyChngedEvent("EventId"); }
        }
        public bool CanUpdate
        {
            get => true;
            // is role is organizer return true
        }
        public ICommand AddTaskCmd
        {
            get;
            private set;
        }

        public List<TaskType> TaskTypes
        {
            get => Enum.GetValues(typeof(TaskType)).Cast<TaskType>().ToList();
        }
        private void InitCommands()
        {
            AddTaskCmd = new AddTaskCommand(this);
        }
        public void AddTask()
        {
            // save Task
        }
    }
}
