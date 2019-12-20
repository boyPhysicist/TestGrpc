using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Services;


namespace Infrastructure.Interfaces
{
    public interface IServersServicesFactory
    {
        ServerService GetServerServiceWithSsl();
        ServerService GetServerServerServiceWithoutSsl();
    }
}
