using Infrastructure.Options;
using Infrastructure.Services.PingService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PingerApp.Pinger;

namespace PingerApp
{
    public class Startup
    {
        public static void Configure(HostBuilderContext hostBuilderContext, IServiceCollection services)
        {
            services.Configure<HostsConfiguration>(hostBuilderContext.Configuration.GetSection(nameof(HostsConfiguration)));
            services.AddHostedService<Worker>();
            services.AddTransient<IPingService, PingService>();
            services.AddTransient<IPingerManager, PingerManager>();
        }
    }
}