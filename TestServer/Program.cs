using System;
using CrossCutting;
using Infrastructure.EnvSetup;
using Infrastructure.Providers;

namespace TestServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serverFactory = new ServersServicesFactory(new CredProvider());

            var server = serverFactory.GetServerServerServiceWithoutSsl();

            server.StartServer();

            Console.WriteLine($"{Defines.ServerListeningMessage}{Defines.Port}");
            Console.WriteLine(Defines.PressAnyKeyServerMessage);
            Console.ReadKey();

            server.ShutdownServerAsync().Wait();
        }
    }
}
