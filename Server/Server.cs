using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;

namespace Server
{
    class Server
    {
        static void Main(string[] args)
        {
            //TcpChannel channel = new TcpChannel(8080);
            //ChannelServices.RegisterChannel(channel, false);

            //RemotingConfiguration.RegisterWellKnownServiceType(
            //    typeof(RemoteObject),
            //    "RemoteObject.rem",
            //    WellKnownObjectMode.Singleton);

            //Console.WriteLine("Сервер запущен. Нажмите enter для остановки.");
            //Console.ReadLine();
            ServerTCP();
            ServerHTTP();
            Console.WriteLine("Сервер запущен. Нажмите enter для остановки.");
            Console.ReadLine();
        }

        static void ServerTCP()
        {
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = TypeFilterLevel.Full;
            IDictionary props = new Hashtable();
            props["port"] = 8080;
            props["name"] = "TCPChannel";
            props["typeFilterLevel"] = TypeFilterLevel.Full;
            props["impersonate"] = false;
            props["secure"] = true;
            props["protectionLevel"] = System.Net.Security.ProtectionLevel.EncryptAndSign;
            TcpChannel tcpChannel = new TcpChannel(props, null, serverProv);
            ChannelServices.RegisterChannel(tcpChannel, true);

            RemotingConfiguration.ApplicationName = "tcp";
            RemotingConfiguration.RegisterActivatedServiceType(typeof(RemoteObjectTCP));
            Console.WriteLine("Канал TCP был создан");
        }

        static void ServerHTTP()
        {
            RemotingConfiguration.Configure("C:/My Files/Универ/3 курс/Технологии программирования/TP_Truckers/Server/ServerConfig.config", true);
            Console.WriteLine("Канал HTTP был создан");
        }

    }
}

