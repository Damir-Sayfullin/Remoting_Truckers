using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;

namespace Truckers
{
    public partial class FormLogin : Form
    {
        RemoteObjectHTTP remoteHTTP; // удаленный объект
        HttpChannel channel = new HttpChannel(new Dictionary<string, string> { { "port", "0" } }, new BinaryClientFormatterSinkProvider(), new BinaryServerFormatterSinkProvider { TypeFilterLevel = TypeFilterLevel.Full });

        bool password_show = false;
        public FormLogin()
        {
            InitializeComponent();
            ConnectToServer();
            this.TopMost = true;
        }

        private void ConnectToServer() // установка соединения с сервером
        {
            ChannelServices.RegisterChannel(channel, false);
            remoteHTTP = new RemoteObjectHTTP();
            ILease lease = (ILease)remoteHTTP.InitializeLifetimeService();
            ClientSponsor clientHTTPSponsor = new ClientSponsor();
            lease.Register(clientHTTPSponsor);
        }

        private void button1_Click(object sender, EventArgs e) // нажатие на кнопку "Войти"
        {
            // проверка на пустные поля
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show(
                        "Введите логин и пароль!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                // вызов метода Autorization у удаленного объекта
                string result = remoteHTTP.Autorization(textBox1.Text, textBox2.Text);
                
                // если пользователей с таким логином и паролем нет
                if (result == "1")
                {
                    MessageBox.Show(
                            "Неверный логин или пароль!",
                            "Ошибка!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                }
                // если такой пользователь логист
                else if (result == "logist")
                {
                    // получение имени пользователя
                    string username = remoteHTTP.GetUsername(textBox1.Text);
                    // переход к форме логиста
                    FormLogist formLogist = new FormLogist(this, username);
                    formLogist.Show();
                    this.Hide();
                }
                // если такой пользователь водитель
                else if (result == "driver")
                {
                    // получение имени пользователя
                    string username = remoteHTTP.GetUsername(textBox1.Text);
                    int ID = remoteHTTP.GetID(textBox1.Text);
                    // переход к форме водителя
                    FormDriver formDriver = new FormDriver(this, username, ID);
                    formDriver.Show();
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
            FormRegister formRegister = new FormRegister(this, remoteHTTP);
            formRegister.Show();
            // скрытие это формы авторизации
            this.Hide();
        }
    }
}
