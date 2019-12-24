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

        public Channel ClientChannel { get; }

        public ClientService(TestService.TestServiceClient client, Channel channel)
        {
            _client = client;
            ClientChannel = channel;
        }

        public string Calculate(Request request)
        {
            try
            {
                var replay = _client.Calculate(request);

                return replay.Message.ToString();
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public async Task<string> CalculateAsync(Request request)
        {
                var replay = await _client.CalculateAsync(request);

                return replay.Message.ToString();
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
