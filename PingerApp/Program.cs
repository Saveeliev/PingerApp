using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PingerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .ConfigureAppConfiguration(cfg => cfg.AddJsonFile("hostsConfiguration.json"))
                .ConfigureLogging(builder => builder.AddConsole())
                .ConfigureServices((hostContext, services) =>
                {
                    Startup.Configure(hostContext, services);
                });
    }
}