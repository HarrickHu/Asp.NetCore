using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRDemo.Controllers
{
    [Route(template: "api/count")]
    public class CountController : Controller
    {
        private readonly IHubContext<CountHub> _countHub;
        public CountController(IHubContext<CountHub> countHub)
        {
            _countHub = countHub;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await _countHub.Clients.All.SendAsync(method: "someFunc", arg1: new { random = "abcd" });
            return Accepted(1);
        }
    }
}
