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

        #endregion


        #region Constructor
        public ToDoAssignment()
        {
            _task = "Empty";
            _dato = DateTime.Now;
        }

        public ToDoAssignment(string task, DateTime dato, int id)
        {
            _task = task;
            _dato = dato;
            _id = id;
        }
        #endregion


    }
}
