using System;
using System.Collections.Generic;
using System.IO;
using CredKeeper;
using Grpc.Core;
using Test;
using CrossCutting;
using Environment.EnvSetup;

namespace TestServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serverFactory = new ServersFactory(new CredProvider());

            var server = serverFactory.GetSslServer();

            server.Start();

            Console.WriteLine($"{Defines.ServerListeningMessage}{Defines.Port}");
            Console.WriteLine(Defines.PressAnyKeyServerMessage);
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
