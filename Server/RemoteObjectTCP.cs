using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Runtime.Remoting.Lifetime;

namespace Server
{
    [Serializable]
    public class RemoteObjectTCP : MarshalByRefObject
    {
        // ссылка на базу данных
        private string connectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:/My Files/Универ/3 курс/Технологии программирования/TP_Truckers/Truckers/data/TruckersDB.mdb";

        public RemoteObjectTCP()
        {
            Console.WriteLine("Удаленный объект TCP создан!");
        }
        ~RemoteObjectTCP()
        {
            Console.WriteLine("Удаленный объект TCP уничтожен!");
        }

        /// <summary>
        /// Получение базы данных
        /// </summary>
        /// <returns>
        /// Таблица DataTable, полученная из базы данных
        /// </returns>
        public DataTable Logist_CargoReload()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();

                DataTable dataTable = new DataTable(); // создание таблицы
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Cargo", connection);
                adapter.Fill(dataTable); // запись результатов выполнения запроса в таблицу

                // закрытие соединения
                connection.Close();

                // возвращение таблицы
                return dataTable;
            }
        }

        /// <summary>
        /// Изменение значений в базе данных по ID
        /// </summary>
        /// <returns>
        /// "0" - если изменение прошло успешно
        /// </returns>
        public string Logist_CargoSave(string ID, string DriverID, string Status, string Cargo, string Weight, string From, string To)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();

                // обновление данных по ID
                string sql = string.Format("UPDATE Cargo SET DriverID={1}, Status='{2}', Cargo='{3}', Weight={4}, [From]='{5}', [To]='{6}' WHERE ID={0}", ID, DriverID, Status, Cargo, Weight, From, To);
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                cmd.ExecuteNonQuery();

                // закрытие соединения
                connection.Close();
                return "0";
            }
        }

        /// <summary>
        /// Добавление записей в базу данных
        /// </summary>
        /// <returns>
        /// "0" - если добавление прошло успешно
        /// </returns>
        public string Logist_CargoAdd(string DriverID, string Status, string Cargo, string Weight, string From, string To)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();

                // добавление данных
                string sql = string.Format("INSERT INTO Cargo (DriverID, Status, Cargo, Weight, [From], [To]) VALUES ({0}, '{1}', '{2}', {3}, '{4}', '{5}')", DriverID, Status, Cargo, Weight, From, To);
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                cmd.ExecuteNonQuery();

                // закрытие соединения
                connection.Close();
                return "0";
            }
        }

        /// <summary>
        /// Удаление записи из базы данных
        /// </summary>
        /// <returns>
        /// "0" - если удаление прошло успешно
        /// </returns>
        public string Logist_CargoDelete(string ID)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();

                // удаление данных по ID
                string sql = string.Format("DELETE FROM Cargo WHERE ID = {0}", ID);
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                cmd.ExecuteNonQuery();

                // закрытие соединения
                connection.Close();
                return "0";
            }
        }

        /// <summary>
        /// Поиск количества грузов по ID водителя
        /// </summary>
        /// <returns>
        /// Количество грузов
        /// </returns>
        public string Logist_GetDriversCount(string DriverID)
        {
            if (DriverID == "0")
                return "0";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();

                // обновление данных по ID
                string sql = string.Format("SELECT * FROM Cargo WHERE DriverID = {0}", DriverID);
                DataTable dataTable = new DataTable(); // создание таблицы
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
                adapter.Fill(dataTable); // запись результатов выполнения запроса в таблицу

                // закрытие соединения
                connection.Close();
                return dataTable.Rows.Count.ToString();
            }
        }

        public byte[] Upload(string path)
        {
            return File.ReadAllBytes("Sources\\" + path);
        }

        public override object InitializeLifetimeService()
        {
            ILease lease = (ILease)base.InitializeLifetimeService();

            if (lease.CurrentState == LeaseState.Initial)
            {
                lease.InitialLeaseTime = TimeSpan.FromSeconds(3);
                lease.SponsorshipTimeout = TimeSpan.FromSeconds(10);
                lease.RenewOnCallTime = TimeSpan.FromSeconds(2);
            }
            return lease;
        }
    }
}
