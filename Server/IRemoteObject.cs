using System;

namespace Server
{
    public interface IRemoteObject
    {
        string Autorization(string login, string password);
        string Registration(string name, string login, string password, string post);
    }
}
