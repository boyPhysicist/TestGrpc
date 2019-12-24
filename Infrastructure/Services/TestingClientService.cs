using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using Service;

namespace Infrastructure.Services
{
    public class TestingClientService
    {
        private readonly Tester.TesterClient _client;
        public Channel ClientChannel { get; }

        public TestingClientService(Tester.TesterClient client, Channel channel)
        {
            _client = client;

            ClientChannel = channel;

        }

        //public async Task IntTestAsync()
        //{
        //    await _client.IntTestAsync(new IntRequest {Value = 1});
        //}

        public void StringTest()
        {
            _client.StringTest(new StringRequest {Value = "Value"});
        }

        //public async Task ByteTestAsync()
        //{
        //    await _client.ByteTestAsync(new ByteRequest {Value = ByteString.CopyFrom(BitConverter.GetBytes(2020)) });
        //}
    }
}
