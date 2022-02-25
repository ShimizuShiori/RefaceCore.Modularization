using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Helpers;
using System;

namespace RefaceCore.Modularization.Starters
{
    /// <summary>
    /// 简单启动器
    /// <typeparamref name="TListener">处理启动后事件的监听器</typeparamref>
    /// </summary>
    public class SimpleAppStarter<TListener> : IAppStarter
        where TListener : class, IOnStartedListener
    {
        private readonly IServiceCollection services;
        private readonly IConfiguration configuration;
        private readonly object startArguments;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="startArguments">启动参数</param>
        public SimpleAppStarter(IServiceCollection services = null, IConfiguration configuration = null, object startArguments = null)
        {
            if (services == null)
                services = new ServiceCollection();
            if (configuration == null)
                configuration = new ConfigurationBuilder().Build();
            this.services = services;
            this.configuration = configuration;
            this.startArguments = startArguments;
        }

        public void Start<T>() where T : IModule
        {
            services.AddSingleton<IOnStartedListener, TListener>();
            ModuleHelper.Start(this.services, this.configuration, typeof(T));

            IServiceProvider sp = this.services.BuildServiceProvider();
            IOnStartedListener listener = sp.GetService<IOnStartedListener>();
            listener.OnStarted(this.startArguments);
        }
    }
}
