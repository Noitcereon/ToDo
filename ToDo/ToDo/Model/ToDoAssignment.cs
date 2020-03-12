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
        private DateTimeOffset _dato;
        private int _id;
        #endregion

        #region Properties

        public string Task
        {
            get => _task;
            set => _task = value;
        }

        public DateTimeOffset Dato
        {
            get => _dato;
            set => _dato = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string DateColorForNotification => Notify();

        #endregion


        #region Constructor
        public ToDoAssignment()
        {
            _task = "Empty";
            _dato = DateTime.Now.AddDays(2);
        }

        public ToDoAssignment(string task, DateTimeOffset dato)
        {
            _task = task;
            _dato = dato;
        }
        #endregion

        #region Methods

        public string Notify()
        {
            bool isNearDeadline = DateTime.Today > Dato.AddDays(-3);

            string color = isNearDeadline ? "Red" : "Black";

            return color;
        }

        #endregion
    }
}
