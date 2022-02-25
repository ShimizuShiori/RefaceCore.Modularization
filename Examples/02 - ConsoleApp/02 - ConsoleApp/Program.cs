using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RefaceCore.Modularization.Starters;
using RefaceCore.Starters.ConsoleApp.Starters;
using System.Threading;
using System.Threading.Tasks;

namespace Ex02ConsoleApp
{
    public class HelloService : IHostedService
    {
        private readonly ILogger<HelloService> logger;

        public HelloService(ILogger<HelloService> logger)
        {
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("HelloWorld");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAppStarter starter = new ConsoleAppStarter();
            starter.Start<Ex02ConsoleAppModule>();
        }
    }
}
