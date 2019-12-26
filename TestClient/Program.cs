using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Test;
using CrossCutting;
using Infrastructure.EnvSetup;
using Infrastructure.Providers;

namespace TestClient
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var clientFabric = new ClientServicesFactory(new CredProvider());

            var clientService = clientFabric.GetClientServiceWithoutSsl();

            var testingClient = clientFabric.GetTestingClientServiceWithoutSsl();

            await testingClient.BigByteTestAsync();

            Console.WriteLine(Defines.InputMessage);

            var result = _GetInputData();

            var calcResult = clientService.Calculate(new Request {Message = result});

            Console.WriteLine(calcResult);

            var calcHugeResult = clientService.CalculateHuge(new HugeRequest
                { Message = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 } }).Result;

            Console.WriteLine(calcHugeResult);

            clientService.ClientChannel.ShutdownAsync().Wait();
            Console.WriteLine(Defines.PressAnyKeyСlientMessage);
            Console.ReadKey();
        }

        private static int _GetInputData()
        {
            var result = 0;

            var isInputCorrect = false;

            while (!isInputCorrect)
            {
                var inputString = Console.ReadLine();

                var isIntValue = int.TryParse(inputString, out result);

                if (!isIntValue)
                {
                    Console.WriteLine(Defines.WrongDataErrorMessage);
                    continue;
                }

                if (result < 0)
                {
                    Console.WriteLine(Defines.WrongValueErrorMessage);
                    continue;
                }

                isInputCorrect = true;
            }

            return result;
        }
        }
}
