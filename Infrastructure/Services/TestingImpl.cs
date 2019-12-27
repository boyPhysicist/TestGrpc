using System;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using Service;

namespace Infrastructure.Services
{
    public class TestingImpl : Tester.TesterBase
    {
        public override Task<ByteReplay> ByteTest(ByteRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ByteReplay { Value = ByteString.CopyFrom(BitConverter.GetBytes(1991)) });
        }

        public override Task<IntReplay> IntTest(IntRequest request, ServerCallContext context)
        {
            return Task.FromResult(new IntReplay { Value = -request.Value });
        }

        public override Task<StringReplay> StringTest(StringRequest request, ServerCallContext context)
        {
            return Task.FromResult(new StringReplay {Value = request.Value.ToUpper()});
        }

        public override Task<ByteReplay> BigByteTest(ByteRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ByteReplay{Value = ByteString.CopyFrom(new byte[100_000_000])});
        }
    }
}
