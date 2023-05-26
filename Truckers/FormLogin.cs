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
using Server;

namespace Truckers
{
    public partial class FormLogin : Form
    {
        public RemoteObjectTCP remoteTCP; // удаленный объект
        bool password_show = false; // показывать пароль

        public FormLogin()
        {
            InitializeComponent();
            ConnectToServer();
        }

        private void ConnectToServer() // установка соединения с сервером
        {
            RemotingConfiguration.Configure("C:/My Files/Универ/3 курс/Технологии программирования/TP_Truckers/Truckers/ClientConfig.config", false);
            remoteTCP = new RemoteObjectTCP();
            ILease lease = (ILease)remoteTCP.InitializeLifetimeService();
            ClientSponsor clientTCPSponsor = new ClientSponsor();
            lease.Register(clientTCPSponsor);
        }

        private void button1_Click(object sender, EventArgs e) // нажатие на кнопку "Войти"
        {
            // проверка на пустные поля
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                this.TopMost = true;
                MessageBox.Show(
                        "Введите логин и пароль!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                this.TopMost = false;
            }
            else
            {
                // вызов метода Autorization у удаленного объекта
                string result = remoteTCP.Autorization(textBox1.Text, textBox2.Text);
                
                // если пользователей с таким логином и паролем нет
                if (result == "0")
                {
                    this.TopMost = true;
                    MessageBox.Show(
                            "Неверный логин или пароль!",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                    this.TopMost = false;
                }
                // если такой пользователь найден
                else
                {
                    // переход к другой форме
                    FormLogist formLogist = new FormLogist(this);
                    formLogist.Show();
                    this.Hide();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)  // нажатие на кнопку скрытия пароля
        {
            password_show = !password_show;
            if (password_show)
            {
                button2.BackgroundImage = Properties.Resources.EyeClosed;
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                button2.BackgroundImage = Properties.Resources.EyeOpened;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // нажатие на кнопку "Зарегистрироваться"
        {
            // открытие формы регистрации
            FormRegister formRegister = new FormRegister(this);
            formRegister.Show();
            // скрытие это формы авторизации
            this.Hide();
        }
    }
}
