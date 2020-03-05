using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDo.Annotations;
using ToDo.Common;
using ToDo.Model;

namespace ToDo.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ToDoAssignment> _assignments;
        private ToDoAssignment _selectedAssignment;
        private ToDoAssignment _newAssignment;
        private bool _showCreateContainer;
        private string _toDoString;
        private DateTime _toDoDateTime;

        public MainPageViewModel()
        {
            _assignments = new ObservableCollection<ToDoAssignment>();
            _showCreateContainer = false;
            OpenCreateContainerBtn = new RelayCommand(OpenCreateContainerBtnMethod);
            CreateNewToDoBtn = new RelayCommand(AddAssignment);
        }

        public RelayCommand CreateNewToDoBtn { get; set; }

        public RelayCommand OpenCreateContainerBtn { get; set; }

        public bool ShowCreateContainer
        {
            get => _showCreateContainer;
            set
            {
                if (value == _showCreateContainer) return;
                _showCreateContainer = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ToDoAssignment> Assignments
        {
            get => _assignments;
            set
            {
                _assignments = value;
                OnPropertyChanged();
            } 
        }

        public ToDoAssignment SelectedAssignment
        {
            get => _selectedAssignment;
            set => _selectedAssignment = value;
        }

        public string ToDoString
        {
            get => _toDoString;
            set
            {
                if (value == _toDoString) return;
                _toDoString = value;
                OnPropertyChanged();
            }
        }

        public DateTime ToDoDateTime
        {
            get => _toDoDateTime;
            set
            {
                if (value.Equals(_toDoDateTime)) return;
                _toDoDateTime = value;
                OnPropertyChanged();
            }
        }

        private void OpenCreateContainerBtnMethod()
        {
            if (ShowCreateContainer)
            {
                ShowCreateContainer = false;
            }
            else
            {
                ShowCreateContainer = true;
            }
        }

        public void AddAssignment()
        {
            _newAssignment = new ToDoAssignment(ToDoString,ToDoDateTime);

            Assignments.Add(_newAssignment);
            ShowCreateContainer = false;
            OnPropertyChanged(nameof(Assignments));
            ToDoString = null;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
