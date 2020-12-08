using Infrastructure.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using PingerApp.PingerManager;

namespace PingerApp
{
    public class Worker : BackgroundService
    {
        private readonly HostsConfiguration _options;
        private readonly IPingerManager _pingerManager;

        public Worker(IOptions<HostsConfiguration> options, IPingerManager pingerManager)
        {
            _options = options.Value;
            _pingerManager = pingerManager ?? throw new ArgumentNullException(nameof(pingerManager));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _pingerManager.StartPinger(_options.Hosts);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}