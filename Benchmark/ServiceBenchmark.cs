using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Infrastructure.EnvSetup;
using Infrastructure.Providers;
using Infrastructure.Services;
using Test;

namespace Benchmark
{
    public class ServiceBenchmark
    {
        private ClientService _clientService;

        [GlobalSetup]
        public void Setup()
        {
            var factory = new ClientServicesFactory(new CredProvider());

            _clientService = factory.GetClientServiceWithoutSsl();

        }

        [Benchmark]
        public void Calculate()
        {
            for (var i = 0; i < 10; ++i)
            {
                var result = _clientService.Calculate(new Request { Message = 1 });
                Console.Write(result);
            }
        }

        [Benchmark]
        public async Task CalculateAsync()
        {
            for (var i = 0; i < 10; ++i)
            {
                var result = await _clientService.CalculateAsync(new Request { Message = 1 });
            }
        }
    }
}
