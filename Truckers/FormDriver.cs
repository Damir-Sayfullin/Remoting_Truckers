using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truckers
{
    public partial class FormDriver : Form
    {
        int ID; // ID водителя
        RemoteObjectTCP remoteTCP; // удаленный объект
        FormLogin formLogin; // ссылка на форму авторизации
        DataTable cargoDataTable; // таблица с грузами
        public FormDriver(FormLogin formLogin, string username, int ID)
        {
            InitializeComponent();
            this.ID = ID;
            this.formLogin = formLogin; // присваивание ссылки на форму авторизации
            label1.Text = "Водитель: " + username; // вывод имени пользователя на форму
            label2.Text = "Ваш ID: " + ID.ToString(); // вывод ID пользователя на форму
            ConnectToServer();
            CargoReload();
            this.TopMost = true;
        }
        private void ConnectToServer() // установка соединения с сервером
        {
            RemotingConfiguration.Configure("C:/My Files/Универ/3 курс/Технологии программирования/TP_Truckers/Truckers/ClientConfig.config", false);
            remoteTCP = new RemoteObjectTCP();
            ILease lease = (ILease)remoteTCP.InitializeLifetimeService();
            ClientSponsor clientTCPSponsor = new ClientSponsor();
            lease.Register(clientTCPSponsor);
        }
        private void CargoReload() // обновление таблицы
        {
            // получение данных 
            cargoDataTable = remoteTCP.Logist_CargoReload();
            // очистка выпадающего списка
            comboBox_ID.Items.Clear();

            // проходим по каждой строке в cargoDataTable
            foreach (DataRow row in cargoDataTable.Rows)
            {
                // получение значения поля ID из текущей строки
                object value = row["ID"];

                // добавление значения в comboBox_ID
                comboBox_ID.Items.Add(value);
            }
        }

        private void comboBox_ID_SelectedValueChanged(object sender, EventArgs e) // при выборе ID в выпадающем списке
        {
            // поиск строк с выбранным ID
            DataRow[] IDRow = cargoDataTable.Select(String.Format("ID = '{0}'", comboBox_ID.SelectedItem.ToString()));
            foreach (DataRow row in IDRow)
            {
                // изменение полей в соответсвии с выбраным ID
                textBoxDriverID.Text = row["DriverID"].ToString();
                textBoxStatus.Text = row["Status"].ToString();
                textBoxCargo.Text = row["Cargo"].ToString();
                textBoxWeight.Text = row["Weight"].ToString();
                textBoxFrom.Text = row["From"].ToString();
                textBoxTo.Text = row["To"].ToString();
            }

        }

        private void buttonExit_Click(object sender, EventArgs e) // при нажатии на кнопку "Выйти из системы"
        {
            // открытие формы авторизации
            formLogin.Show();
            // закрытие этой формы водителя
            this.Close();
            // освобождение памяти
            this.Dispose();
        }

        private void buttonCurrent_Click(object sender, EventArgs e) // при нажатии на кнопку "Текущий груз"
        {
            // получение данных о текущем грузе
            DataTable driverCargo = remoteTCP.Driver_GetCargo(ID.ToString());
            // проверка на наличие груза у водителя
            if (driverCargo.Rows.Count != 0)
            {
                foreach (DataRow row in driverCargo.Rows)
                {
                    // изменение полей в соответсвии с ID водителя
                    comboBox_ID.Text = row["ID"].ToString();
                    textBoxDriverID.Text = row["DriverID"].ToString();
                    textBoxStatus.Text = row["Status"].ToString();
                    textBoxCargo.Text = row["Cargo"].ToString();
                    textBoxWeight.Text = row["Weight"].ToString();
                    textBoxFrom.Text = row["From"].ToString();
                    textBoxTo.Text = row["To"].ToString();
                }
            }
            else
            {
                MessageBox.Show(
                            string.Format("У вас нет активного груза!", textBoxDriverID.Text),
                            "Ошибка!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            // проверка на пустое ID
            if (comboBox_ID.Text == "")
            {
                MessageBox.Show(
                        "Выберите ID!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                // получение данных о текущем грузе
                DataTable driverCargo = remoteTCP.Driver_GetCargo(ID.ToString());
                // проверка на наличие груза у водителя
                if (driverCargo.Rows.Count == 0)
                {
                    // проверка на наличие водителей у выбранного груза
                    if (remoteTCP.Driver_GetDriverID(comboBox_ID.Text) == 0)
                    {
                        // принятие груза 
                        int result = remoteTCP.Driver_CargoAccept(comboBox_ID.Text, ID.ToString());
                        // если все прошло успешно
                        if (result == 0)
                        {
                            MessageBox.Show(
                                    string.Format("Груз принят!\n ID = {0}\n Груз: {1}\n Из: {2}\n В: {3}", comboBox_ID.Text, textBoxCargo.Text, textBoxFrom.Text, textBoxTo.Text),
                                    "Успех!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.DefaultDesktopOnly);
                        }
                        else
                        {
                            MessageBox.Show(
                                string.Format("Этот груз уже был доставлен!", textBoxDriverID.Text),
                                "Ошибка!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                        }
                        // обновление таблицы
                        CargoReload();
                    }
                    else
                    {
                        MessageBox.Show(
                                string.Format("У этого груза уже есть водитель!", textBoxDriverID.Text),
                                "Ошибка!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
                else
                {
                    MessageBox.Show(
                                string.Format("У вас уже есть активный груз!", textBoxDriverID.Text),
                                "Ошибка!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // получение данных о текущем грузе
            DataTable driverCargo = remoteTCP.Driver_GetCargo(ID.ToString());
            // проверка на наличие груза у водителя
            if (driverCargo.Rows.Count != 0)
            {
                // требование подтверждения отказа от груза
                if (MessageBox.Show(
                            string.Format("Вы действительно хотите отказаться от груза?\n ID = {0}\n Груз: {1}\n Из: {2}\n В: {3}", driverCargo.Rows[0]["ID"].ToString(), driverCargo.Rows[0]["Cargo"], driverCargo.Rows[0]["From"], driverCargo.Rows[0]["To"]),
                            "Внимание!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Yes)
                {
                    // отказ от груза 
                    int result = remoteTCP.Driver_CargoCancel(ID.ToString());
                    // если все прошло успешно
                    if (result == 0)
                    {
                        MessageBox.Show(
                                string.Format("Ваш груз отменен!"),
                                "Успех!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                    }
                    // обновление таблицы
                    CargoReload();
                }
            }
            else
            {
                MessageBox.Show(
                            string.Format("У вас нет активного груза!", textBoxDriverID.Text),
                            "Ошибка!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void buttonDelivery_Click(object sender, EventArgs e)
        {
            // получение данных о текущем грузе
            DataTable driverCargo = remoteTCP.Driver_GetCargo(ID.ToString());
            // проверка на наличие груза у водителя
            if (driverCargo.Rows.Count != 0)
            {
                // требование подтверждения доставки груза
                if (MessageBox.Show(
                            string.Format("Вы действительно хотите завершить доставку?\n ID = {0}\n Груз: {1}\n Из: {2}\n В: {3}", driverCargo.Rows[0]["ID"].ToString(), driverCargo.Rows[0]["Cargo"], driverCargo.Rows[0]["From"], driverCargo.Rows[0]["To"]),
                            "Внимание!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Yes)
                {
                    // завершение доставки груза 
                    int result = remoteTCP.Driver_CargoDelivery(ID.ToString());
                    // если все прошло успешно
                    if (result == 0)
                    {
                        MessageBox.Show(
                                string.Format("Ваш груз доставлен!"),
                                "Успех!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                    }
                    // обновление таблицы
                    CargoReload();
                }
            }
            else
            {
                MessageBox.Show(
                            string.Format("У вас нет активного груза!", textBoxDriverID.Text),
                            "Ошибка!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
