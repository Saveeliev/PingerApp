using Infrastructure.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _pingerManager.StartPinger(_options.Hosts);

            return Task.CompletedTask;
        }
    }
}