using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRDemo
{
    public class CountHub: Hub
    {
        private readonly CountService _countService;

        public CountHub(CountService countService)
        {
            _countService = countService;
        }

        public async Task GetLatestCount(string random)
        {
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
    }
}
