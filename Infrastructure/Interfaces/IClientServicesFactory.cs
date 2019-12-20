using Infrastructure.Services;

namespace Infrastructure.Interfaces
{
    public interface IClientServicesFactory
    {
        ClientService GetClientServiceWithSsl();
        ClientService GetClientServiceWithoutSsl();
    }
}
