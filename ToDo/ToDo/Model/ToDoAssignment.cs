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
        //private string _dateColorForNotification;
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
            get { return Notify(); }
            //set { _dateColorForNotification = value; }
        }

        #endregion


        #region Constructor
        public ToDoAssignment()
        {
            //_dateColorForNotification = "Red";
            _task = "Empty";
            _dato = DateTime.Now.AddDays(2);
        }

        public ToDoAssignment(string task, DateTime dato)
        {
            _task = task;
            _dato = dato;
            //_id = id;
            //_dateColorForNotification = "Black";
        }
        #endregion

        #region Methods

        public string Notify()
        {
            bool isNearDeadline = DateTime.Today > Dato.AddDays(-3);
            //bool isNearDeadline = true;


            string color = isNearDeadline ? "Red" : "Black";

            return color;
        }

        #endregion
    }
}
