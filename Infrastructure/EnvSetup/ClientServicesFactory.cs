using System.Collections.Generic;
using CrossCutting;
using Grpc.Core;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Test;

namespace Infrastructure.EnvSetup
{
    public class ClientServicesFactory : IClientServicesFactory
    {
        private readonly ICredentialsProvider _credentialsProvider;

        public ClientServicesFactory(ICredentialsProvider credentialsProvider)
        {
            _credentialsProvider = credentialsProvider;
        }

        public ClientService GetClientServiceWithSsl()
        {
            var channelOptions = new List<ChannelOption>
            {
                new ChannelOption(ChannelOptions.SslTargetNameOverride, Defines.PcName)
            };

            var channelCredentials = _credentialsProvider.GetSslClientCredentials();

            var channel = new Channel(Defines.PcName, Defines.Port, channelCredentials, channelOptions);

            var client = new ClientService(new TestService.TestServiceClient(channel), channel);

            return client;
        }

        public ClientService GetClientServiceWithoutSsl()
        {
            var channel = new Channel(Defines.PcName, Defines.Port, ChannelCredentials.Insecure);

            var client = new ClientService(new TestService.TestServiceClient(channel), channel);

            return client;
        }
    }
}
