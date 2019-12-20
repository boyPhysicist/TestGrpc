using Infrastructure.Models;

namespace Infrastructure.Interfaces
{
    public interface IClientFactory
    {
        Client GetSslClient();
        Client GetClient();
    }
}
