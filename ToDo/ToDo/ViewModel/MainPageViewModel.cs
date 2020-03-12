using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using ToDo.Annotations;
using ToDo.Common;
using ToDo.DbUtility;
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
        private Manager _manager;
        private DateTimeOffset _toDoDateTime = DateTimeOffset.Now;

        public MainPageViewModel()
        {
            _assignments = new ObservableCollection<ToDoAssignment>();
            _manager = new Manager();
            _assignments = _manager.GetAll();
            _showCreateContainer = false;
            OpenCreateContainerBtn = new RelayCommand(OpenCreateContainerBtnMethod);
            CreateNewToDoBtn = new RelayCommand(AddAssignment);
            DeleteToDoBtn = new RelayCommand(DeleteTask);
        }

        public RelayCommand DeleteToDoBtn { get; set; }

        

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

        public DateTimeOffset ToDoDateTime
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
            _manager.Create(_newAssignment);
            ShowCreateContainer = false;
            ToDoString = null;
        }

        private void DeleteTask()
        {
            if (SelectedAssignment == null) return;
            _manager.Delete(SelectedAssignment);
            Assignments.Remove(SelectedAssignment);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
