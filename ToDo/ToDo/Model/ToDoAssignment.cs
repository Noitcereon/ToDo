using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model
{
    public class ToDoAssignment
    {
        #region Instans felter
        private string _task;
        private DateTime _dato;
        private string _dateColorForNotification;
        private int _id;
        #endregion

        #region Properties

        public string Task
        {
            get => _task;
            set => _task = value;
        }

        public DateTime Dato
        {
            get => _dato;
            set => _dato = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string DateColorForNotification
        {
            get { return _dateColorForNotification; }
            set { _dateColorForNotification = value; }
        }

        #endregion


        #region Constructor
        public ToDoAssignment()
        {
            _dateColorForNotification = "Red";
            _task = "Empty";
            _dato = DateTime.Now;
        }

        public ToDoAssignment(string task, DateTime dato)
        {
            _task = task;
            _dato = dato;
            //_id = id;
            _dateColorForNotification = "Black";
        }
        #endregion

        #region Methods

        public bool Notify()
        {
            bool isNearDeadline = DateTime.Now > Dato.Date.Subtract(TimeSpan.FromDays(3));

            DateColorForNotification = isNearDeadline ? "Red" : "Black";

            return isNearDeadline;
        }

        #endregion
    }
}
