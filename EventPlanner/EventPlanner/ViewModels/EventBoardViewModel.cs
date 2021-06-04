using EventPlanner.Commands;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        }
        public ICommand SelectionChangedCmd
        {
            get;
            private set;
        }
        private void AddOriginalData()
        {
            _ToDoTasks.Clear(); _InProgressTasks.Clear(); _DoneTasks.Clear();

            Collaborator collaborator = new Collaborator { Name = "coll1", Address = "addr1", Type = CollaboratorType.FLOWER_SHOP };
            List<Task> toDoTasks = new List<Task>();
            List<Task> inProgressTasks = new List<Task>();
            List<Task> doneTasks = new List<Task>();
            List<Event> allUsersEvents = new List<Event>();
            toDoTasks.Add(new Task(TaskStatus.TO_DO, 1, "200 red roses at flower shop 'Maria' sdgsfgdf dfg fder ", collaborator, TaskType.GENERIC));
            toDoTasks.Add(new Task(TaskStatus.TO_DO, 1, "task 2", collaborator, TaskType.GENERIC));
            inProgressTasks.Add(new Task(TaskStatus.TO_DO, 1, "task 3", collaborator, TaskType.GENERIC));
            doneTasks.Add(new Task(TaskStatus.TO_DO, 1, "pice kod mice", collaborator, TaskType.GENERIC));

            Event e = new Event(1, "eventic", EventType.BIRTHDAY, "desc 1", DateTime.Now, DateTime.Now, new User("micko", "micko123", "Mica", "Lakic"));
            _Event = e;
            allUsersEvents.Add(e);
            allUsersEvents.Add(new Event(2, "title event 2", EventType.BIRTHDAY, "event 1 desc 2", DateTime.Now, DateTime.Now, new User("micko", "micko123", "Mica", "Lakic")));
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
            toDoTasks.Add(new Task(TaskStatus.TO_DO, 1, "Clean out Tivoli Enterprise Console database", collaborator, TaskType.GENERIC));
            inProgressTasks.Add(new Task(TaskStatus.TO_DO, 1, "Forward event to the Tivoli Enterprise Console server", collaborator, TaskType.GENERIC));
            inProgressTasks.Add(new Task(TaskStatus.TO_DO, 1, "Jump Netscape to URL", collaborator, TaskType.GENERIC));

            toDoTasks.ForEach(_ToDoTasks.Add);
            inProgressTasks.ForEach(_InProgressTasks.Add);
            doneTasks.ForEach(_DoneTasks.Add);
        }
    }
}
