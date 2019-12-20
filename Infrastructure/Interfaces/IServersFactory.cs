using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Models;


namespace Infrastructure.Interfaces
{
    public interface IServersFactory
    {
        Server GetSslServer();
        Server GetServer();
    }
}
