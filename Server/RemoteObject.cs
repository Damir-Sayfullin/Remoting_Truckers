using System;
using System.Data;
using System.Data.OleDb;

namespace Server
{
    [Serializable]
    public class RemoteObject : MarshalByRefObject, IRemoteObject
    {
        // 2 канала связи с защитой
        // один с конфига, один с кода
        //должен быть спонсор
        // в ремотинге только интерфейс
        // в ремотинге часть программы должен быть у клиента

        // в асп нет кода у клиента нет

        // на этой неделе 
        // вторник 9 40 11 20 353

        private string connectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:/My Files/Универ/3 курс/Технологии программирования/Truckers/data/TruckersDB.mdb";
        public string Autorization(string login, string password)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                DataTable dataTable = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Format("SELECT * FROM Users WHERE Login='{0}' AND Password='{1}'", login, password), connection);
                adapter.Fill(dataTable);

                connection.Close();

                return Convert.ToString(dataTable.Rows.Count);
            }
        }

        public string Registration(string name, string login, string password, string post)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // проверка на повтор логина
                DataTable dataTable = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Users WHERE Login='" + login + "'", connection);
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count == 0)
                {
                    string sql = string.Format("INSERT INTO Users ([Username], [Post], [Login], [Password]) VALUES ('{0}', '{1}', '{2}', '{3}')", name, post, login, password);
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return "0";
                }
                else
                {
                    connection.Close();
                    return "1";
                }
            }
        }
    }
}
