using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;

namespace Truckers
{
    public partial class FormLogin : Form
    {
        bool password_show = false;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                this.TopMost = true;
                MessageBox.Show(
                        "Введите логин и пароль!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                this.TopMost = false;
            }
            else
            {
                try
                {
                    IRemoteObject remoteObject = (IRemoteObject)Activator.GetObject(
                            typeof(IRemoteObject),
                            "tcp://localhost:8080/RemoteObject.rem");
                    string result = remoteObject.Autorization(textBox1.Text, textBox2.Text);
                
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
                    else
                    {
                        FormLogist formLogist = new FormLogist(this);
                        formLogist.Show();
                        this.Hide();
                    }
                }
                catch
                {
                    this.TopMost = true;
                    MessageBox.Show(
                            "Не удалось подключиться к серверу!",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                    this.TopMost = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister formRegister = new FormRegister(this);
            formRegister.Show();
            this.Hide();
        }
    }
}
