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
        public string Logist_CargoSave(string ID, string DriverID, string Status, string Cargo, string Weight, string From, string To) // изменение данных в 
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();

                // обновление данных по ID
                string sql = string.Format("UPDATE Cargo SET DriverID={1}, Status='{2}', Cargo='{3}', Weight={4}, [From]='{5}', [To]='{6}' WHERE ID={0}", ID, DriverID, Status, Cargo, Weight, From, To);
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                return "0";
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
