﻿using Infrastructure.Options;
using Infrastructure.Services.LoggerProvider;
using Infrastructure.Services.LogService;
using Infrastructure.Services.PingService;
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
            services.AddTransient<ILoggerProvider, LoggerProvider>();
        }
    }
}