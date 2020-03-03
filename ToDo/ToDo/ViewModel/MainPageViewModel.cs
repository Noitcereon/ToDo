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
        private bool _showCreateContainer;
        public MainPageViewModel()
        {
            _assignments = new ObservableCollection<ToDoAssignment>();
            _showCreateContainer = false;
            OpenCreateContainerBtn = new RelayCommand(OpenCreateContainerBtnMethod);
        }

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
            set => _assignments = value;
        }

        public ToDoAssignment SelectedAssignment
        {
            get => _selectedAssignment;
            set => _selectedAssignment = value;
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
