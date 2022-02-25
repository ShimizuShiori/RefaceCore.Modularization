using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RefaceCore.Modularization;
using RefaceCore.Modularization.Helpers;
using RefaceCore.Modularization.Starters;
using System;
using System.Threading;

namespace RefaceCore.Starters.ConsoleApp.Starters
{
    public class ConsoleAppStarter : IAppStarter
    {
        public void Start<T>() where T : IModule
        {
            var serverhost = new HostBuilder()
                   .ConfigureAppConfiguration((hostcontext, config) =>
                   {
                       config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                       config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                   })
                   .ConfigureLogging((hostContext, builder) =>
                   {
                       builder.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                       builder.AddConsole();
                   })
                   .ConfigureServices((hostBuilderContext, services) =>
                   {
                       ModuleHelper.Start(services, hostBuilderContext.Configuration, typeof(T));
                   });

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;


            serverhost.RunConsoleAsync(ct)
                .GetAwaiter()
                .GetResult();
        }
    }
}
