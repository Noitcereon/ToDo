using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Common;
using ToDo.Model;

namespace ToDo.ViewModel
{
    public class MainPageViewModel
    {
        private ObservableCollection<ToDoAssignment> _assignments;
        private ToDoAssignment _selctedAssignment;
        private bool _showCreateContainer;
        public MainPageViewModel()
        {
            _assignments = new ObservableCollection<ToDoAssignment>();
            _showCreateContainer = false;
            OpenCreateContainerBtn = new RelayCommand(OpenCreateContainerBtnMethod);
        }

        public RelayCommand OpenCreateContainerBtn { get; set; }

        public bool ShowCreateContainer => _showCreateContainer;

        public ObservableCollection<ToDoAssignment> Assignments
        {
            get => _assignments;
            set => _assignments = value;
        }

        public ToDoAssignment SelectedAssignment
        {
            get => _selctedAssignment;
            set => _selctedAssignment = value;
        }

        private void OpenCreateContainerBtnMethod()
        {
            _showCreateContainer = true;
        }
    }
}
