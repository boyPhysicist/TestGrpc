using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Infrastructure.EnvSetup;
using Infrastructure.Providers;
using Infrastructure.Services;


namespace Benchmark
{
    public class ServiceBenchmark
    {
        private TestingClientService _clientService;

        [GlobalSetup]
        public void Setup()
        {
            var factory = new ClientServicesFactory(new CredProvider());

            _clientService = factory.GetTestingClientServiceWithoutSsl();

        }

        [Benchmark]
        public async Task IntBench()
        {
            for (var i = 1; i < 1000; i++)
            {
                await _clientService.IntTestAsync();
            }
        }

        [Benchmark]
        public async Task ByteBench()
        {
            for (var i = 1; i < 1000; i++)
            {
                await _clientService.ByteTestAsync();
            }
        }

        [Benchmark]
        public async Task StringBench()
        {
            for (var i = 1; i < 1000; i++)
            {
                await _clientService.StringTestAsync();
            }
        }

        [Benchmark]
        public async Task BigByteBench()
        {
            await _clientService.BigByteTestAsync();
        }
    }
}
