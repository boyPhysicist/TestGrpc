using CrossCutting;
using Grpc.Core;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Test;
using Server = Infrastructure.Models.Server;

namespace Environment.EnvSetup
{
    public class ServersFactory : IServersFactory
    {

        private readonly ICredentialsProvider _credentialsProvider;

        public ServersFactory(ICredentialsProvider credentialsProvider)
        {
            _credentialsProvider = credentialsProvider;
        }

        public Server GetSslServer()
        {
            var cred = _credentialsProvider.GetSslServerCredentials();

            var server = new Server(new Grpc.Core.Server
            {
                Services = {TestService.BindService(new ServiceImpl())},
                Ports = {new ServerPort(Defines.HostName, Defines.Port, cred)}
            });

            return server;
        }

        public Server GetServer()
        {
            var server = new Server(new Grpc.Core.Server
            {
                Services = { TestService.BindService(new ServiceImpl()) },
                Ports = { new ServerPort(Defines.HostName, Defines.Port, ServerCredentials.Insecure) }
            });

            return server;
        }
    }
}
