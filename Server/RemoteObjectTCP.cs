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

        /// <summary>
        /// Получение данных о грузе по ID водителя
        /// </summary>
        /// <returns>
        /// Данные о грузе
        /// </returns>
        public DataTable Driver_GetCargo(string DriverID)
        {
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
                return dataTable;
            }
        }

        /// <summary>
        /// Получение ID водителя груза по ID груза
        /// </summary>
        /// <returns>
        /// ID водителя - если у груза есть водитель
        /// и 0 - если у водителя нет груза
        /// </returns>
        public int Driver_GetDriverID(string ID)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();

                // обновление данных по ID
                string sql = string.Format("SELECT * FROM Cargo WHERE ID = {0}", ID);
                DataTable dataTable = new DataTable(); // создание таблицы
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
                adapter.Fill(dataTable); // запись результатов выполнения запроса в таблицу

                // закрытие соединения
                connection.Close();
                return Convert.ToInt32(dataTable.Rows[0]["DriverID"]);
            }
        }

        /// <summary>
        /// Взятие груза по ID груза и ID водителя
        /// </summary>
        /// <returns>
        /// 0 - если все прошло успешно
        /// и 1 - если груз уже был доставлен
        /// </returns>
        public int Driver_CargoAccept(string ID, string DriverID)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();

                DataTable dataTable = new DataTable(); // создание таблицы
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Cargo WHERE ID=" + ID, connection);
                adapter.Fill(dataTable); // запись результатов выполнения запроса в таблицу

                // проверка статуса груза
                if (dataTable.Rows[0]["Status"].ToString() == "ready for unloading")
                {
                    // обновление данных по ID
                    string sql = string.Format("UPDATE Cargo SET DriverID={1}, Status='on the way' WHERE ID={0}", ID, DriverID);
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    // закрытие соединения
                    connection.Close();
                    return 0;
                }
                else
                {
                    // закрытие соединения
                    connection.Close();
                    return 1;
                }
            }
        }

        /// <summary>
        /// Отказ от груза по ID груза и ID водителя
        /// </summary>
        /// <returns>
        /// 0 - если все прошло успешно
        /// </returns>
        public int Driver_CargoCancel(string DriverID)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();

                // обновление данных по ID
                string sql = string.Format("UPDATE Cargo SET DriverID=0, Status='ready for unloading' WHERE DriverID={0}", DriverID);
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                cmd.ExecuteNonQuery();

                // закрытие соединения
                connection.Close();
                return 0;
            }
        }

        /// <summary>
        /// Доставка груза по ID груза и ID водителя
        /// </summary>
        /// <returns>
        /// 0 - если все прошло успешно
        /// </returns>
        public int Driver_CargoDelivery(string DriverID)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();

                // обновление данных по ID
                string sql = string.Format("UPDATE Cargo SET DriverID=0, Status='delivered' WHERE DriverID={0}", DriverID);
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                cmd.ExecuteNonQuery();

                // закрытие соединения
                connection.Close();
                return 0;
            }
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
