using System.Threading.Tasks;
using Grpc.Core;
using Test;

namespace Infrastructure.Services
{
    public class ServiceImpl : TestService.TestServiceBase
    {
        public override Task<Reply> Calculate(Request request, ServerCallContext context)
        {
            return Task.FromResult(Calculate(request.Message));
        }

        public override async Task CalculateHuge(HugeRequest request, IServerStreamWriter<Reply> responseStream, ServerCallContext context)
        {
            foreach (var value in request.Message)
            {
                await responseStream.WriteAsync(Calculate(value));
            }
        }

        private Reply Calculate(long value)
        {
            var result = 0;

            for (var i = 0; i<=value; i++)
            {
                result += i * i;
            }

            return new Reply{ Message = result };
        }
    }
}
