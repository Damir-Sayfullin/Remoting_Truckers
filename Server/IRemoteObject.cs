using System;
using System.Data;

namespace Server
{
    public interface IRemoteObject
    {
        string Autorization(string login, string password);
        string Registration(string name, string login, string password, string post);
        DataTable ReloadCargo();
    }
}
