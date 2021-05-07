using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Services;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRDemo
{
    //[Authorize]
    public class CountHub: Hub
    {
        private readonly CountService _countService;

        public CountHub(CountService countService)
        {
            _countService = countService;
        }

        public async Task GetLatestCount(string random)
        {
            //var user = Context.User.Identity.Name;
            int count;
            do
            {
                count = _countService.GetLatestCount();
                Thread.Sleep(millisecondsTimeout: 1000);
                await Clients.All.SendAsync(method: "ReceiveUpdate", count);
            }
            while (count < 10);

            await Clients.All.SendAsync(method: "Finished");
        }

        public override async Task OnConnectedAsync()
        {
            //var connectionId = Context.ConnectionId;
            //var client = Clients.Client(connectionId);

            //await client.SendAsync(method: "someFunc", new { });
            //await Clients.AllExcept(connectionId).SendAsync(method: "someFunc");

            //await Groups.AddToGroupAsync(connectionId, "MyGroup");
            //await Groups.RemoveFromGroupAsync(connectionId, "MyGroup");

            //await Clients.Groups("MyGroup").SendAsync(method: "someFunc", new { });
        }
    }
}
