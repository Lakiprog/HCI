using EventPlanner.Commands;
using EventPlanner.Models;
using EventPlanner.Services;
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
        private EventBoardViewModel _EventBoardViewModel;
        public TaskViewModel(EventBoardViewModel eventBoardViewModel)
        {
            _EventBoardViewModel = eventBoardViewModel;
            _EventId = EventBoardViewModel.Event.Id;
            var e = EventService.Singleton().GetEventInfo(EventId);
            int newId = e.Tasks.Count()+1;
            _Task = new Task(newId, "", TaskStatus.WAITING, TaskLevel.TO_DO, EventId, "", null, TaskType.GENERIC);
            _Temp = new Task(_Task);
            //_Task.Level = TaskLevel.TO_DO;
            _Mode = Mode.Adding;
            InitCommands();
        }
        public TaskViewModel(Task task)
        {
            _Task = task;
            _EventId = task.EventId;
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
            get => UserService.Singleton().CurrentUser is Organizer;
        }
        public Task Temp
        {
            get => _Temp;
            set { _Temp = value; RaisePropertyChngedEvent("Temp"); }
        }
        public EventBoardViewModel EventBoardViewModel
        {
            get => _EventBoardViewModel;
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
            _Temp.Level = TaskLevel.TO_DO;
            _Temp.EventId = EventId;
            EventBoardViewModel.ToDoTasks.Add(_Temp);
            // save Task
            var e = EventService.Singleton().GetEventInfo(EventId);
            e.Tasks.Add(_Temp);
            EventService.Singleton().Modify(e);
            EventBoardViewModel.Event = EventService.Singleton().GetEventInfo(EventId);
        }
        public void EditTask()
        {
            // edit Task
            _Task.Title = _Temp.Title;
            _Task.Description = _Temp.Description;
            _Task.Level = _Temp.Level;

            var e = EventService.Singleton().GetEventInfo(EventId);
            var task = e.Tasks.First(e => e.Id == _Task.Id);
            task.Title = _Task.Title;
            task.Description = _Task.Description;
            task.Level = _Task.Level;
            EventService.Singleton().Modify(e);
        }
        public bool CanUpdate()
        {
            if (String.IsNullOrWhiteSpace(_Temp.Title) || String.IsNullOrWhiteSpace(_Temp.Description)) return false;
            return true;
        }
    }
}
