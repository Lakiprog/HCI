using EventPlanner.Commands;
using EventPlanner.Models;
using EventPlanner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace EventPlanner.ViewModels
{
    class EventBoardViewModel : ObservableObject
    {
        private ObservableCollection<Task> _ToDoTasks;
        private ObservableCollection<Task> _InProgressTasks;
        private ObservableCollection<Task> _DoneTasks;
        private Event _Event;
        private ObservableCollection<Event> _AllUsersEvents;
        public EventBoardViewModel()
        {
            InitData();
            InitCommands();
        }
        public ObservableCollection<Task> ToDoTasks
        {
            get => _ToDoTasks;
            set { _ToDoTasks = value; RaisePropertyChngedEvent("ToDoTasks"); }
        }


        public ObservableCollection<Task> InProgressTasks
        {
            get => _InProgressTasks;
            set { _InProgressTasks = value; RaisePropertyChngedEvent("InProgressTasks"); }
        }
        public ObservableCollection<Task> DoneTasks
        {
            get => _DoneTasks;
            set { _DoneTasks = value; RaisePropertyChngedEvent("DoneTasks"); }
        }
        public Event Event
        {
            get => _Event;
            set { _Event = value; RaisePropertyChngedEvent("Event"); }
        }
        public ObservableCollection<Event> AllUsersEvents
        {
            get => _AllUsersEvents;
            set { _AllUsersEvents = value; RaisePropertyChngedEvent("AllUsersEvents"); }
        }
        public bool IsOrganizer
        {
            get => UserService.Singleton().CurrentUser is Organizer;
        }
        
        private void InitData()
        {
            _ToDoTasks = new ObservableCollection<Task>();
            _InProgressTasks = new ObservableCollection<Task>();
            _DoneTasks = new ObservableCollection<Task>();
            _AllUsersEvents = new ObservableCollection<Event>();
            
            AddOriginalData();
        }
        private void InitCommands()
        {
            SelectionChangedCmd = new SelectionChangedCommand(this);
            OpenCreateTaskModalCmd = new OpenCreateTaskModalCommand(this);
            OpenViewItemModalCmd = new OpenViewItemModalCommand();
            DeleteTaskCmd = new DeleteTaskCommand(this);
            AcceptTaskCmd = new AcceptTaskCommand(this);
            RejectTaskCmd = new RejectTaskCommand(this);
            MoveTaskCmd = new MoveTaskCommand(this);
        }
        public ICommand SelectionChangedCmd
        {
            get;
            private set;
        }
        public ICommand OpenCreateTaskModalCmd
        {
            get;
            private set;
        }
        public ICommand OpenViewItemModalCmd
        {
            get; private set;
        }
        public ICommand DeleteTaskCmd
        {
            get; private set;
        }
        public ICommand AcceptTaskCmd
        {
            get; private set;
        }
        public ICommand RejectTaskCmd
        {
            get; private set;
        }
        public ICommand MoveTaskCmd
        {
            get; private set;
        }
        private void AddOriginalData()
        {
            _ToDoTasks.Clear(); _InProgressTasks.Clear(); _DoneTasks.Clear();

            Collaborator collaborator = new Collaborator { Name = "coll1", Address = "addr1", Type = CollaboratorType.FLOWER_SHOP };
            List<Task> toDoTasks = new List<Task>();
            List<Task> inProgressTasks = new List<Task>();
            List<Task> doneTasks = new List<Task>();
            List<Event> allUsersEvents = new List<Event>();
            toDoTasks.Add(new Task("Naslov koji nije toliko dugacak", TaskStatus.WAITING, TaskLevel.TO_DO, 1, "opis koji je dugacak 200 red roses at flower shop 'Maria' sdgsfgdf dfg fder ", collaborator, TaskType.GENERIC));
            toDoTasks.Add(new Task("Izbor restorana", TaskStatus.WAITING, TaskLevel.TO_DO, 1, "task 2", collaborator, TaskType.GENERIC));
            toDoTasks.Add(new Task("Izbor restorana 2", TaskStatus.ACCEPTED, TaskLevel.TO_DO, 1, "task 2", collaborator, TaskType.GENERIC));
            toDoTasks.Add(new Task("Izbor restorana 3", TaskStatus.REJECTED, TaskLevel.TO_DO, 1, "task 2", collaborator, TaskType.GENERIC));
            inProgressTasks.Add(new Task("title 3", TaskStatus.WAITING, TaskLevel.IN_PROGRESS, 1, "task 3", collaborator, TaskType.GENERIC));
            doneTasks.Add(new Task("cvece", TaskStatus.WAITING, TaskLevel.DONE, 1, "pice kod mice", collaborator, TaskType.GENERIC));

            Event e = new Event(1, "eventic", EventType.BIRTHDAY, "desc 1", DateTime.Now, DateTime.Now, new User(1,"micko", "micko123", "Mica", "Lakic"));
            _Event = e;
            allUsersEvents.Add(e);
            allUsersEvents.Add(new Event(2, "title event 2", EventType.BIRTHDAY, "event 1 desc 2", DateTime.Now, DateTime.Now, new User(1,"micko", "micko123", "Mica", "Lakic")));
            allUsersEvents.ForEach(_AllUsersEvents.Add);

            toDoTasks.ForEach(_ToDoTasks.Add);
            inProgressTasks.ForEach(_InProgressTasks.Add);
            doneTasks.ForEach(_DoneTasks.Add);
        }
        public void ChangeCurrentEvent(Event _event)
        {
            Event = _event;
            _ToDoTasks.Clear(); _InProgressTasks.Clear(); _DoneTasks.Clear();
            // get new events tasks
            List<Task> toDoTasks = new List<Task>();
            List<Task> inProgressTasks = new List<Task>();
            List<Task> doneTasks = new List<Task>();
            Collaborator collaborator = new Collaborator { Name = "coll1", Address = "addr1", Type = CollaboratorType.FLOWER_SHOP };
            toDoTasks.Add(new Task("Baloni", TaskStatus.ACCEPTED, TaskLevel.TO_DO, 1, "Clean out Tivoli Enterprise Console database", collaborator, TaskType.GENERIC));
            inProgressTasks.Add(new Task("Cvece", TaskStatus.ACCEPTED, TaskLevel.IN_PROGRESS, 1, "Forward event to the Tivoli Enterprise Console server", collaborator, TaskType.GENERIC));
            inProgressTasks.Add(new Task("Hrana", TaskStatus.ACCEPTED, TaskLevel.IN_PROGRESS, 1, "Jump Netscape to URL", collaborator, TaskType.GENERIC));

            toDoTasks.ForEach(_ToDoTasks.Add);
            inProgressTasks.ForEach(_InProgressTasks.Add);
            doneTasks.ForEach(_DoneTasks.Add);
        }
        public void DeleteTask(Task task)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (_ToDoTasks.Contains(task)) _ToDoTasks.Remove(task);
                else if (_InProgressTasks.Contains(task)) _InProgressTasks.Remove(task);
                else _DoneTasks.Remove(task);
            }
        }
        public void AcceptTask(Task task)
        {
            task.Status = TaskStatus.ACCEPTED;
        }
        public void RejectTask(Task task)
        {
            task.Status = TaskStatus.REJECTED;
        }
        public void MoveTask(dynamic moveTask)
        {
            if (moveTask.ListFromLevel == TaskLevel.TO_DO) _ToDoTasks.Remove(moveTask.Task);
            else if (moveTask.ListFromLevel == TaskLevel.IN_PROGRESS) _InProgressTasks.Remove(moveTask.Task);
            else _DoneTasks.Remove(moveTask.Task);

            if (moveTask.ListToLevel == TaskLevel.TO_DO) _ToDoTasks.Add(moveTask.Task);
            else if (moveTask.ListToLevel == TaskLevel.IN_PROGRESS) _InProgressTasks.Add(moveTask.Task);
            else _DoneTasks.Add(moveTask.Task);

            moveTask.Task.Level = moveTask.ListToLevel;
            // update task
        }
    }
}
