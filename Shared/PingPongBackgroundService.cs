using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
namespace Shared
{
    public class PingPongBackgroundService : IHostedService
    {
        public PingPongBackgroundService()
        {

        }

        private void PingNetwork()
        {
            Ping ping = new Ping();
            var pingReply = ping.Send(IPAddress.Parse("192.168.0.1"), 20);
            Console.WriteLine(pingReply.Status);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
             PingNetwork();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stop Called, Perform Cleanup here");
            return null;
        }
    }
}
