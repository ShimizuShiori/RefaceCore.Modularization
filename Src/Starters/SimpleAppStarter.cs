using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Helpers;

namespace RefaceCore.Modularization.Starters
{
    /// <summary>
    /// 简单启动器
    /// </summary>
    public class SimpleAppStarter : IAppStarter
    {
        private readonly IServiceCollection services;
        private readonly IConfiguration configuration;

        public SimpleAppStarter(IServiceCollection services = null, IConfiguration configuration = null)
        {
            if (services == null)
                services = new ServiceCollection();
            if (configuration == null)
                configuration = new ConfigurationBuilder().Build();
            this.services = services;
            this.configuration = configuration;
        }

        public void Start<T>() where T : IModule
        {
            ModuleHelper.Start(this.services, this.configuration, typeof(T));
        }
    }
}
