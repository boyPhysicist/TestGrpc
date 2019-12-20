using System;
using System.Collections.Generic;
using System.Text;
using CrossCutting;
using Grpc.Core;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Test;

namespace Environment.EnvSetup
{
    public class ClientFactory : IClientFactory
    {
        private readonly ICredentialsProvider _credentialsProvider;

        public ClientFactory(ICredentialsProvider credentialsProvider)
        {
            _credentialsProvider = credentialsProvider;
        }

        public Client GetSslClient()
        {
            var channelOptions = new List<ChannelOption>
            {
                new ChannelOption(ChannelOptions.SslTargetNameOverride, Defines.PcName)
            };

            var channelCredentials = _credentialsProvider.GetSslClientCredentials();

            var channel = new Channel(Defines.PcName, Defines.Port, channelCredentials, channelOptions);

            var client = new Client(new TestService.TestServiceClient(channel), channel);

            return client;
        }

        public Client GetClient()
        {
            var channel = new Channel(Defines.PcName, Defines.Port, ChannelCredentials.Insecure);

            var client = new Client(new TestService.TestServiceClient(channel), channel);

            return client;
        }
    }
}
