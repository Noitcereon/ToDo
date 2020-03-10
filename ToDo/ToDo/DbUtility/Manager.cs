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

        public ObservableCollection<ToDoAssignment> GetAll()
        {
            ObservableCollection<ToDoAssignment> returListe = new ObservableCollection<ToDoAssignment>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Task",conn))
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

        private ToDoAssignment ReadNext(SqlDataReader reader)
        {
            ToDoAssignment newObject = new ToDoAssignment();

            newObject.Task = reader.GetString(1);
            newObject.Dato = reader.GetDateTimeOffset(2);

            return newObject;
        }
    }
}
