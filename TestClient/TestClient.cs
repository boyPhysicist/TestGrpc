using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace TestClient
{
    public class TestClient
    {
        private readonly TestService.TestServiceClient _client;

        public TestClient(TestService.TestServiceClient client)
        {
            _client = client;
        }

        public void Calculate(Request request)
        {
            try
            {
                var replay = _client.Calculate(request);

                WriteToConsole($"{Defines.ResultString}{replay.Message}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        public async Task CalculateHuge(HugeRequest request)
        {
            try
            {
                using (var call = _client.CalculateHuge(request))
                {
                    var stream = call.ResponseStream;
                    var resultString = new StringBuilder("Result: ");

                    while (await stream.MoveNext())
                    {
                        var replay = stream.Current;
                        resultString.Append($"{replay.Message},");
                    }

                    WriteToConsole(resultString.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void WriteToConsole(string input)
        {
            Console.WriteLine(input);
        }
    }
}
