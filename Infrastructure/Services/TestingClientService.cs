using System;
using System.Collections.Generic;
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

        public async Task<IntReplay> IntTestAsync()
        {
            var result = await _client.IntTestAsync(new IntRequest { Value = 1 });

            return result;
        }

        public async Task<StringReplay> StringTestAsync()
        {
            var result = await _client.StringTestAsync(new StringRequest {Value = "Value"});

            return result;
        }

        public async Task<ByteReplay> ByteTestAsync()
        {
           var result = await _client.ByteTestAsync(new ByteRequest { Value = ByteString.CopyFrom(BitConverter.GetBytes(2020)) });

           return result;
        }

        public async Task<ByteReplay> BigByteTestAsync()
        {
            var result = await _client.BigByteTestAsync(new ByteRequest());
            return result;
        }
    }
}
