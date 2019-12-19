using System;
using System.Collections.Generic;
using System.IO;
using Grpc.Core;
using Test;

namespace TestServer
{
    class Program
    {
        static SslServerCredentials GetCerts()
        {
            var certsFolder = Path.Combine(Environment.CurrentDirectory, "Certs");
            var caCert = File.ReadAllText(Path.Combine(certsFolder, "ca.crt"));
            var cert = File.ReadAllText(Path.Combine(certsFolder, "server.crt"));
            var key = File.ReadAllText(Path.Combine(certsFolder, "server.key"));

            var certificateCollection = new List<KeyCertificatePair>
            {
                new KeyCertificatePair(cert, key)
            };

            var serverCredentials = new SslServerCredentials(certificateCollection, caCert, SslClientCertificateRequestType.RequestAndRequireButDontVerify);
            return serverCredentials;
        }

        static void Main(string[] args)
        {
            var cred = GetCerts();

            var server = new Server
            {
                Services = {TestService.BindService(new ServiceImpl())},
                Ports = {new ServerPort(Defines.HostName, Defines.Port, cred)}
            };

            server.Start();

            Console.WriteLine($"{Defines.ServerListeningMessage}{Defines.Port}");
            Console.WriteLine(Defines.PressAnyKeyMessage);
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
