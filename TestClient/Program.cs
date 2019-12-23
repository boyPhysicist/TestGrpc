using System;
using Test;
using CrossCutting;
using Infrastructure.EnvSetup;
using Infrastructure.Providers;

namespace TestClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            var clientFabric = new ClientServicesFactory(new CredProvider());

            var clientService = clientFabric.GetClientServiceWithSsl();

            Console.WriteLine(Defines.InputMessage);

            var inputString = Console.ReadLine();

            var result = _CheckForCorrectInput(inputString);

            var calcResult = clientService.Calculate(new Request {Message = result});

            Console.WriteLine(calcResult);

            var calcHugeResult = clientService.CalculateHuge(new HugeRequest
                { Message = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 } }).Result;

            Console.WriteLine(calcHugeResult);

            clientService.ClientChannel.ShutdownAsync().Wait();
            Console.WriteLine(Defines.PressAnyKeyСlientMessage);
            Console.ReadKey();
        }

        private static int _CheckForCorrectInput(string inputString)
        {
            int result;

            while (true)
            {
                while (!int.TryParse(inputString, out result))
                {
                    Console.WriteLine(Defines.WrongDataErrorMessage);

                    inputString = Console.ReadLine();
                }

                if (result < 1 || result > 5)
                {
                    Console.WriteLine(Defines.WrongValueErrorMessage);

                    inputString = Console.ReadLine();

                    continue;
                }

                break;
            }

            return result;
        }
    }
}
