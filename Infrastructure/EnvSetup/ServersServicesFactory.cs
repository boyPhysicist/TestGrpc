using CrossCutting;
using Grpc.Core;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Test;
using ServerService = Infrastructure.Services.ServerService;

namespace Infrastructure.EnvSetup
{
    public class ServersServicesFactory : IServersServicesFactory
    {

        private readonly ICredentialsProvider _credentialsProvider;

        public ServersServicesFactory(ICredentialsProvider credentialsProvider)
        {
            _credentialsProvider = credentialsProvider;
        }

        public ServerService GetServerServiceWithSsl()
        {
            var cred = _credentialsProvider.GetSslServerCredentials();

            var server = new ServerService(new Grpc.Core.Server
            {
                Services = {TestService.BindService(new ServiceImpl())},
                Ports = {new ServerPort(Defines.HostName, Defines.Port, cred)}
            });

            return server;
        }

        public ServerService GetServerServerServiceWithoutSsl()
        {
            var server = new ServerService(new Grpc.Core.Server
            {
                Services = { TestService.BindService(new ServiceImpl()) },
                Ports = { new ServerPort(Defines.HostName, Defines.Port, ServerCredentials.Insecure) }
            });

            return server;
        }
    }
}
