using System;
using System.Collections.Generic;
using System.IO;
using Grpc.Core;
using Test;
using CrossCutting;

namespace TestServer
{
    internal class Program
    {
        private static SslServerCredentials GetCerts()
        {
            var certsFolder = Path.Combine(Environment.CurrentDirectory, Defines.CertificatesFolderName);
            var caCert = File.ReadAllText(Path.Combine(certsFolder, Defines.CaCertificateName));
            var cert = File.ReadAllText(Path.Combine(certsFolder, Defines.ServerCertificateName));
            var key = File.ReadAllText(Path.Combine(certsFolder, Defines.ServerCertificateKeyName));

            var certificateCollection = new List<KeyCertificatePair>
            {
                new KeyCertificatePair(cert, key)
            };

            var serverCredentials = new SslServerCredentials(certificateCollection, caCert, SslClientCertificateRequestType.RequestAndRequireButDontVerify);
            return serverCredentials;
        }

        private static void Main(string[] args)
        {
            var cred = GetCerts();

            var server = new Server
            {
                Services = {TestService.BindService(new ServiceImpl())},
                Ports = {new ServerPort(Defines.HostName, Defines.Port, cred)}
            };

            server.Start();

            Console.WriteLine($"{Defines.ServerListeningMessage}{Defines.Port}");
            Console.WriteLine(Defines.PressAnyKeyServerMessage);
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
