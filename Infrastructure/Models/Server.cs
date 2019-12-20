using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Server
    {
        private readonly Grpc.Core.Server _server;

        public Server(Grpc.Core.Server server)
        {
            _server = server;
        }

        public void Start()
        {
            _server.Start();
        }

        public async Task ShutdownAsync()
        {
            await _server.ShutdownAsync();
        }
    }
}
