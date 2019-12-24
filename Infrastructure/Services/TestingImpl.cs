using System;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Grpc.Core;
using Service;

namespace Infrastructure.Services
{
    public class TestingImpl : Tester.TesterBase
    {
        public override Task<ByteReplay> ByteTest(ByteRequest request, ServerCallContext context)
        {
            var a = BitConverter.GetBytes(1991);

            return Task.FromResult(new ByteReplay { Value = ByteString.CopyFrom(a) });
        }

        public override Task<IntReplay> IntTest(IntRequest request, ServerCallContext context)
        {
            return Task.FromResult(new IntReplay { Value = -request.Value });
        }

        public override Task<StringReplay> StringTest(StringRequest request, ServerCallContext context)
        {
            return Task.FromResult(new StringReplay {Value = request.Value.ToUpper()});
        }

        public override Task<BigByteReplay> BigByteTest(BigByteRequest request, ServerCallContext context)
        {
            foreach (var str in request.Value)
            {
                var length = str.Length;

                var s = length.ToString();
            }

            return Task.FromResult(new BigByteReplay());
        }
    }
}
