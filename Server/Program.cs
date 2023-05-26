using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(8080);
            ChannelServices.RegisterChannel(channel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(RemoteObject),
                "RemoteObject.rem",
                WellKnownObjectMode.Singleton);

            Console.WriteLine("Сервер запущен. Нажмите enter для остановки.");
            Console.ReadLine();
        }
    }
}

