using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ServerService
    {
        private readonly Grpc.Core.Server _server;

        public ServerService(Grpc.Core.Server server)
        {
            _server = server;
        }

        public void StartServer()
        {
            _server.Start();
        }

        public async Task ShutdownServerAsync()
        {
            await _server.ShutdownAsync();
        }
    }
}
