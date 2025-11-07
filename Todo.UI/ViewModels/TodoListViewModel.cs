using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Todo.UI.Models;
using Todo.UI.Data;

namespace Todo.UI.ViewModels
{
    public class TodoListViewModel : INotifyPropertyChanged
    {
        private string _newTodoTitle;
        private ObservableCollection<TodoItem> _todoItems;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string NewTodoTitle
        {
            get
            {
                return _newTodoTitle;
            }
            set
            {
                _newTodoTitle = value;
                OnPropertyChanged(nameof(NewTodoTitle));     
            }
        }
        public ICommand AddTodoCommand { get; private set; }
        public ICommand LoadDataCommand { get; private set; }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<TodoItem> TodoItems
        {
            get => _todoItems;
            set
            {
                _todoItems = value;
            }
        }

        public TodoListViewModel()
        {
            this.TodoItems = new ObservableCollection<TodoItem>();

            //TODO: Initialise commands:
            AddTodoCommand = new Command(AddTodo);
            LoadDataCommand = new Command(LoadData);
        }

        private void LoadData()
        {
            Console.WriteLine("Loading data...");
            TodoDb.GetTodoItems(10).ForEach(item => TodoItems.Add(item));
        }
        private void AddTodo()
        {
            //TODO: add item to TodoItems, use NewTodoTitle as Title for the new item
            TodoItems.Add(new TodoItem { Title = NewTodoTitle });
            NewTodoTitle = string.Empty;

            //TODO: clear the NewTodoTitle
        }

        private void DeleteTodo(TodoItem item)
        {
            //TODO: remove item from TodoItems
        }
    }
}
