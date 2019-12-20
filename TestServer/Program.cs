using System;
using System.Collections.Generic;
using System.IO;
using CredKeeper;
using Grpc.Core;
using Test;
using CrossCutting;
using Infrastructure.EnvSetup;

namespace TestServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serverFactory = new ServersServicesFactory(new CredProvider());

            var server = serverFactory.GetServerServiceWithSsl();

            server.Start();

            Console.WriteLine($"{Defines.ServerListeningMessage}{Defines.Port}");
            Console.WriteLine(Defines.PressAnyKeyServerMessage);
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
