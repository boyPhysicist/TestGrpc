using BenchmarkDotNet.Attributes;
using Infrastructure.EnvSetup;
using Infrastructure.Providers;
using Infrastructure.Services;
using Jint;
using Test;

namespace Benchmark
{
    public class ServiceBenchmark
    {
        private ClientService _clientService;
        private Engine _engine;

        [GlobalSetup]
        public void Setup()
        {
            var factory = new ClientServicesFactory(new CredProvider());

            _clientService = factory.GetClientServiceWithoutSsl();

            _engine = new Engine();

        }

        [Benchmark]
        public void Calculate()
        {
            for (var i = 0; i < 1000; ++i)
            {
                var result = _clientService.Calculate(new Request { Message = 1 });
            }
        }
    }
}
