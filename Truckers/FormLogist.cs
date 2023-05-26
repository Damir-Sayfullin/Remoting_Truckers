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
    public partial class FormLogist : Form
    {
        public RemoteObjectTCP remoteTCP; // удаленный объект
        private FormLogin formLogin; // ссылка на форму авторизации
        public FormLogist(FormLogin formLogin)
        {
            InitializeComponent();
            this.formLogin = formLogin; // присваивание ссылки на форму авторизации
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

        
    }
}
