using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Certificates;
using ToDo.Model;

namespace ToDo.DbUtility
{
    public class Manager
    {
        private const string ConnectionString = "Data Source=serverdamsgaard.database.windows.net;" +
                                                "Initial Catalog=ToDoDB;User ID=zealandadmin;Password=admin1234?;" +
                                                "Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;" +
                                                "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #region GetAll
        public ObservableCollection<ToDoAssignment> GetAll()
        {
            ObservableCollection<ToDoAssignment> returListe = new ObservableCollection<ToDoAssignment>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Task", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        returListe.Add(ReadNext(reader));
                    }
                }
            }

            return returListe;
        }
        #endregion

        #region Create
        public void Create(ToDoAssignment newToDo)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Task (task_title, task_deadline) VALUES (@task_title, @task_deadline) ", conn))
                {
                    cmd.Parameters.AddWithValue("@task_title", newToDo.Task);
                    cmd.Parameters.AddWithValue("@task_deadline", newToDo.Dato);

                    cmd.ExecuteNonQuery();

                }
            }
        }
        #endregion

        #region Delete
        public void Delete(ToDoAssignment toDo)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Task WHERE task_id = @task_id", conn))
                {
                    cmd.Parameters.AddWithValue("@task_id", toDo.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        public void MoveToDone(ToDoAssignment toDo)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Task SET task_done = true WHERE task_id = @task_id", conn))
                {
                    cmd.Parameters.AddWithValue("@task_id", toDo.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ObservableCollection<ToDoAssignment> GetAllDone()
        {
            ObservableCollection<ToDoAssignment> returListe = new ObservableCollection<ToDoAssignment>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Task WHERE task_done = true", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        returListe.Add(ReadNext(reader));
                    }
                }
            }

            return returListe;
        }

        #region Update
        public void Update(ToDoAssignment toDo)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Task SET task_title = @task_title, " +
                                                             "task_deadline = @task_deadline WHERE task_id = @task_id", conn))
                {
                    cmd.Parameters.AddWithValue("@task_id", toDo.Id);
                    cmd.Parameters.AddWithValue("@task_title", toDo.Task);
                    cmd.Parameters.AddWithValue("@task_deadline", toDo.Dato);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region ReadNext
        private ToDoAssignment ReadNext(SqlDataReader reader)
        {
            ToDoAssignment newObject = new ToDoAssignment();
            newObject.Id = reader.GetInt32(0);
            newObject.Task = reader.GetString(1);
            newObject.Dato = reader.GetDateTimeOffset(2);

            return newObject;
        } 
        #endregion
    }
}
