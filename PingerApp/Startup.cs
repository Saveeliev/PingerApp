using Infrastructure.Handlers.LogHandler;
using Infrastructure.Options;
using Infrastructure.Request;
using Infrastructure.Services.LoggerFactory;
using Infrastructure.Services.LogService;
using Infrastructure.Services.PingService;
using Infrastructure.Services.RequestFactory;
using Infrastructure.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PingerApp.PingerManager;

namespace PingerApp
{
    public class Startup
    {
        public static void Configure(HostBuilderContext hostBuilderContext, IServiceCollection services)
        {
            services.Configure<HostsConfiguration>(hostBuilderContext.Configuration.GetSection(nameof(HostsConfiguration)));
            services.Configure<LogOptions>(hostBuilderContext.Configuration.GetSection(nameof(LogOptions)));
            services.AddHostedService<Worker>();
            services.AddTransient<IPingService, PingService>();
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IPingerManager, PingerManager.PingerManager>();
            services.AddTransient<ILoggerFactory, LoggerFactory>();
            services.AddTransient<IRequestFactory, RequestFactory>();
            services.AddTransient<HostValidator>();
            services.AddTransient<LogToConsole>();
            services.AddTransient<LogToFile>();
            services.AddTransient<HttpRequest>();
            services.AddTransient<IcmpRequest>();
            services.AddTransient<TcpRequest>();
        }
    }
}