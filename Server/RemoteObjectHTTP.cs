﻿using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.Remoting.Lifetime;

namespace Server
{
    [Serializable]
    public class RemoteObjectHTTP : MarshalByRefObject
    {
        // ссылка на базу данных
        private string connectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:/My Files/Универ/3 курс/Технологии программирования/Remoting_Truckers/Truckers/data/TruckersDB.mdb";

        public RemoteObjectHTTP()
        {
            Console.WriteLine("Удаленный объект HTTP создан!");
        }
        ~RemoteObjectHTTP()
        {
            Console.WriteLine("Удаленный объект HTTP уничтожен!");
        }

        /// <summary>
        /// Поиск пользователей по логину и паролю
        /// </summary>
        /// <returns>
        /// Количество пользователей с таким логином и паролем
        /// </returns>
        public string Autorization(string login, string password)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();
                DataTable dataTable = new DataTable(); // создание таблицы
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Format("SELECT * FROM Users WHERE Login='{0}' AND Password='{1}'", login, password), connection);
                adapter.Fill(dataTable); // запись результатов выполнения запроса в таблицу
                // закрытие соединения
                connection.Close();
                // если пользователь с таким логином и паролем не найден
                if (dataTable.Rows.Count == 0)
                    return "1";
                else
                {
                    // если пользователь водитель
                    if (dataTable.Rows[0][2].ToString() == "Водитель")
                        return "driver";
                    // если пользователь логист
                    else if (dataTable.Rows[0][2].ToString() == "Логист")
                        return "logist";
                    else
                        return "1";
                }
            }
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <returns>
        /// "0" - если регистрация успешна
        /// "1" - если пользователь с таким логином уже существует
        /// </returns>
        public string Registration(string name, string login, string password, string post)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();
                // проверка на повтор логина
                DataTable dataTable = new DataTable(); // создание таблицы
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Users WHERE Login='" + login + "'", connection);
                adapter.Fill(dataTable); // запись результатов выполнения запроса в таблицу
                // если пользователей с таким логином не существует
                if (dataTable.Rows.Count == 0)
                {
                    // регистрация нового пользователя
                    string sql = string.Format("INSERT INTO Users ([Username], [Post], [Login], [Password]) VALUES ('{0}', '{1}', '{2}', '{3}')", name, post, login, password);
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return "0";
                }
                // если пользователь с таким логином уже существует
                else
                {
                    connection.Close();
                    return "1";
                }
            }
        }

        /// <summary>
        /// Вывод имени пользователя по логину
        /// </summary>
        /// <returns>
        /// Имя пользователя
        /// </returns>
        public string GetUsername(string login)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();
                DataTable dataTable = new DataTable(); // создание таблицы
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Format("SELECT * FROM Users WHERE Login='{0}'", login), connection);
                adapter.Fill(dataTable); // запись результатов выполнения запроса в таблицу
                // закрытие соединения
                connection.Close();
                // вывод имени пользователя
                return dataTable.Rows[0][1].ToString();
            }
        }

        /// <summary>
        /// Вывод ID пользователя по логину
        /// </summary>
        /// <returns>
        /// ID пользователя
        /// </returns>
        public int GetID(string login)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // открытие соединения
                connection.Open();
                DataTable dataTable = new DataTable(); // создание таблицы
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Format("SELECT * FROM Users WHERE Login='{0}'", login), connection);
                adapter.Fill(dataTable); // запись результатов выполнения запроса в таблицу
                // закрытие соединения
                connection.Close();
                // вывод имени пользователя
                return Convert.ToInt32(dataTable.Rows[0][0]);
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
