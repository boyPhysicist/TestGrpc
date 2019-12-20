using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Test;

namespace TestWebPart.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IClientServicesFactory _clientFactory;

        public DataController(IClientServicesFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public int Get(int param)
        {
            var client = _clientFactory.GetSslClient();

            return client.Calculate(new Request { Message = param });
        }

        [Route("getHuge")]
        [HttpGet]
        public async Task<string> GetHuge()
        {
            var client = _clientFactory.GetSslClient();

            var result = await client.CalculateHuge(new HugeRequest(new HugeRequest
                { Message = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 } }));

            return result;
        }
    }
}