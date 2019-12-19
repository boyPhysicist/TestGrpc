using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Grpc.Core;
using Test;

namespace TestClient
{
    class Program
    {
        static SslCredentials GetSslCredentials()
        {
            var certificatePath = Path.Combine(Environment.CurrentDirectory, "Certs");
            var caCert = File.ReadAllText(Path.Combine(certificatePath, "ca.crt"));
            var cert = File.ReadAllText(Path.Combine(certificatePath, "client.crt"));
            var key = File.ReadAllText(Path.Combine(certificatePath, "client.key"));

            var keyPair = new KeyCertificatePair(cert, key);
            var Creds = new SslCredentials(caCert, keyPair);
            return Creds;
        }

        public static void Main(string[] args)
        {
            var channelOptions = new List<ChannelOption>
            {
                new ChannelOption(ChannelOptions.SslTargetNameOverride, Defines.PcName)
            };

            var channelCredentials = GetSslCredentials();

           var channel = new Channel(Defines.PcName, 50051, channelCredentials, channelOptions);

           var client = new TestClient(new TestService.TestServiceClient(channel)); 

           Console.WriteLine(Defines.InputMessage);

           var inputString = Console.ReadLine();

           CheckForCorrectInput(inputString, out var result);

           client.Calculate(new Request {Message = result});

           client.CalculateHuge(new HugeRequest
            { Message = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 } }).Wait();

            channel.ShutdownAsync().Wait();
            Console.WriteLine(Defines.PressAnyKeyMessage);
            Console.ReadKey();
        }

        private static void CheckForCorrectInput(string inputString, out int result)
        {
            CheckForCorrectString(inputString, out result);

            if (result < 1 || result > 5)
            {
                Console.WriteLine(Defines.WrongValueErrorMessage);

                inputString = Console.ReadLine();

                CheckForCorrectString(inputString, out _);

                CheckForCorrectInput(inputString, out result);
            }

            void CheckForCorrectString(string input, out int value)
            {
                while (!int.TryParse(input, out value))
                {
                    Console.WriteLine(Defines.WrongDataErrorMessage);

                    input = Console.ReadLine();
                }
            }
        }
    }
}
