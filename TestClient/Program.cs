using System;
using System.Collections.Generic;
using System.IO;
using CredKeeper;
using Grpc.Core;
using Test;
using CrossCutting;
using Environment.EnvSetup;

namespace TestClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            var clientFabric = new ClientFactory(new CredProvider());

            var client = clientFabric.GetSslClient();

            Console.WriteLine(Defines.InputMessage);

            var inputString = Console.ReadLine();

            CheckForCorrectInput(inputString, out var result);

            var calcResult = client.Calculate(new Request {Message = result});

            Console.WriteLine(calcResult);

            var calcHugeResult = client.CalculateHuge(new HugeRequest
                { Message = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 } }).Result;

            Console.WriteLine(calcHugeResult);

            client.ClientChannel.ShutdownAsync().Wait();
            Console.WriteLine(Defines.PressAnyKeyСlientMessage);
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
