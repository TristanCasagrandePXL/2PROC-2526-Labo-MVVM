using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.UI.Models
{
    public class TodoItem : INotifyPropertyChanged
    {
        private string _title;
        private string _description;
        private bool _isCompleted;
        private DateTime _dueDate;

        public string Title { get { return _title; } set { _title = value; OnPropertyChanged(nameof(Title)); }}
        public string Description { get => _description; set => _description = value; }
        public bool IsCompleted { get { return _isCompleted; } set { _isCompleted = value; OnPropertyChanged(nameof(IsCompleted)); }}
        public DateTime DueDate { get => _dueDate; set => _dueDate = value; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
