using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.v2.API.Hubs
{
    public class MyHub : Hub
    {
        //Methods can clients call
        public static List<string> Names { get; set; } = new List<string>();
        public async Task SendName(string name)
        {
            Names.Add(name);
            await Clients.All.SendAsync("ReceiveName", name);
        }


        public async Task GetName()
        {
            await Clients.All.SendAsync("ReceviveNames", Names);
        }

    }
}
