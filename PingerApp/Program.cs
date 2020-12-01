using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

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
                .ConfigureServices((hostContext, services) =>
                {
                    Startup.Configure(hostContext, services);
                });
    }
}