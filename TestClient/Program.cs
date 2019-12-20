using System;
using System.Collections.Generic;
using System.IO;
using CredKeeper;
using Grpc.Core;
using Test;
using CrossCutting;
using Infrastructure.EnvSetup;

namespace TestClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            var clientFabric = new ClientServicesFactory(new CredProvider());

            var client = clientFabric.GetClientServiceWithSsl();

            Console.WriteLine(Defines.InputMessage);

            var inputString = Console.ReadLine();

            var result = 0;

            var isInputDataCorrect = false;

            while (!isInputDataCorrect)
            {
                isInputDataCorrect = _CheckForCorrectInput(inputString, out result);
            }

            var calcResult = client.Calculate(new Request {Message = result});

            Console.WriteLine(calcResult);

            var calcHugeResult = client.CalculateHuge(new HugeRequest
                { Message = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 } }).Result;

            Console.WriteLine(calcHugeResult);

            client.ClientChannel.ShutdownAsync().Wait();
            Console.WriteLine(Defines.PressAnyKeyСlientMessage);
            Console.ReadKey();
        }

        private static bool _CheckForCorrectInput(string inputString, out int result)
        {
            _CheckForCorrectString(inputString, out result);

            if (result < 1 || result > 5)
            {
                Console.WriteLine(Defines.WrongValueErrorMessage);

                inputString = Console.ReadLine();

                _CheckForCorrectString(inputString, out _);

                _CheckForCorrectInput(inputString, out result);
            }
        }

        private void _CheckForCorrectString(string input, out int value)
        {
            while (!int.TryParse(input, out value))
            {
                Console.WriteLine(Defines.WrongDataErrorMessage);

                input = Console.ReadLine();
            }
        }
    }
}
