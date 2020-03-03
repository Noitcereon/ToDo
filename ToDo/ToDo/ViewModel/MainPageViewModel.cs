using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model;

namespace ToDo.ViewModel
{
    public class MainPageViewModel
    {
        private ObservableCollection<ToDoAssignment> _assignments;
        private ToDoAssignment _selctedAssignment;
        public MainPageViewModel()
        {
            _assignments = new ObservableCollection<ToDoAssignment>();
        }

        public ObservableCollection<ToDoAssignment> Assignments
        {
            get => _assignments;
            set => _assignments = value;
        }

        public ToDoAssignment SelctedAssignment
        {
            get => _selctedAssignment;
            set => _selctedAssignment = value;
        }
    }
}
