using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CrossCutting;
using Grpc.Core;
using Test;

namespace Infrastructure.Services
{
    public class ClientService
    {
        private readonly TestService.TestServiceClient _client;

        public Channel ClientChannel { get; private set; }

        public ClientService(TestService.TestServiceClient client, Channel channel)
        {
            _client = client;
            ClientChannel = channel;
        }

        public int Calculate(Request request)
        {
            try
            {
                var replay = _client.Calculate(request);

                return replay.Message;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<string> CalculateHuge(HugeRequest request)
        {
            try
            {
                using var call = _client.CalculateHuge(request);
                var stream = call.ResponseStream;
                var resultString = new StringBuilder(Defines.ResultString);

                while (await stream.MoveNext(new CancellationToken()))
                {
                    var replay = stream.Current;
                    resultString.Append($"{replay.Message},");
                }

                resultString.Remove(resultString.Length - 1, 1);

                return resultString.ToString();
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
