﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    public partial class FormRegister : Form
    {
        public RemoteObjectHTTP remoteHTTP; // удаленный объект
        HttpChannel channel = new HttpChannel(new Dictionary<string, string> { { "port", "0" } }, new BinaryClientFormatterSinkProvider(), new BinaryServerFormatterSinkProvider { TypeFilterLevel = TypeFilterLevel.Full });

        bool password_show = false; // показывать пароль
        private FormLogin formLogin; // ссылка на форму авторизации
        public FormRegister(FormLogin formLogin)
        {
            InitializeComponent();
            this.formLogin = formLogin; // присваивание ссылки на форму авторизации
            ConnectToServer();
        }

        private void ConnectToServer() // установка соединения с сервером
        {
            ChannelServices.RegisterChannel(channel, false);
            remoteHTTP = new RemoteObjectHTTP();
            ILease lease = (ILease)remoteHTTP.InitializeLifetimeService();
            ClientSponsor clientHTTPSponsor = new ClientSponsor();
            lease.Register(clientHTTPSponsor);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // открытие формы авторизации
            formLogin.Show();
            // закрытие этой формы регистрации
            this.Close();
            // освобождение памяти
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e) // нажатие на кнопку "ОТправить"
        {
            // проверка на пустые поля
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
            {
                this.TopMost = true;
                MessageBox.Show(
                        "Не все поля заполнены!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                this.TopMost = false;
            }
            else
            {
                // вызов метода Registration у удаленного объекта
                string result = remoteHTTP.Registration(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text);

                // если регистрация успешна
                if (result == "0")
                {
                    this.TopMost = true;
                    MessageBox.Show(
                            "Регистрация прошла успешно!",
                            "Успех!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                    this.TopMost = false;
                }
                // если пользователь с таким логином уже существует
                else if (result == "1")
                {
                    this.TopMost = true;
                    MessageBox.Show(
                            "Пользователь с таким логином уже существует!",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                    this.TopMost = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // нажатие на кнопку скрытия пароля
        {
            password_show = !password_show;
            if (password_show)
            {
                button2.BackgroundImage = Properties.Resources.EyeClosed;
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                button2.BackgroundImage = Properties.Resources.EyeOpened;
                textBox3.UseSystemPasswordChar = true;
            }
        }
    }
}
