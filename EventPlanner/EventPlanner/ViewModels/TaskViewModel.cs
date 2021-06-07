using EventPlanner.Commands;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    public enum Mode { Viewing, Editing, Adding }
    class TaskViewModel : ObservableObject
    {
        private Task _Task;
        private Task _Temp;
        private int _EventId;
        private Mode _Mode;
        public TaskViewModel(int eventId)
        {
            _Task = new Task();
            _Temp = new Task(_Task);
            _EventId = eventId;
            _Task.Status = TaskStatus.TO_DO;
            _Mode = Mode.Adding;
            InitCommands();
        }
        public TaskViewModel(Task task)
        {
            _Task = task;
            _Temp = new Task(_Task);
            _Mode = Mode.Viewing;
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
        
        public Mode Mode
        {
            get => _Mode;
            set { _Mode = value; RaisePropertyChngedEvent("Mode"); RaisePropertyChngedEvent("IsEditing"); }
        }
        public bool IsOrganizer
        {
            get => true;
        }
        public Task Temp
        {
            get => _Temp;
            set { _Temp = value; RaisePropertyChngedEvent("Temp"); }
        }
        public bool IsEditing
        {
            get => this.Mode != Mode.Viewing;
        }
        public ICommand AddTaskCmd
        {
            get;
            private set;
        }
        public ICommand EnableEditingTaskCmd
        {
            get;
            private set;
        }
        public ICommand EditTaskCmd
        {
            get;
            private set;
        }
        public ICommand CancelEditingTaskCmd
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
            EnableEditingTaskCmd = new EnableEditingTaskCommand(this);
            EditTaskCmd = new EditTaskCommand(this);
            CancelEditingTaskCmd = new CancelEditingTaskCommand(this);
        }
        public void AddTask()
        {
            // save Task
        }
        public void EditTask()
        {
            // edit Task
        }
    }
}
