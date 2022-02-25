using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Attributes;
using RefaceCore.Modularization.Helpers;
using System;
using System.Reflection;

namespace RefaceCore.Modularization.StartingTools.ComponentRegistions
{
    [StartingTool(typeof(IComponentRegistion))]
    public class OptionRegistion : IComponentRegistion
    {
        private readonly IConfiguration configuration;

        public OptionRegistion(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void OnTypeScanned(IServiceCollection services, Type type)
        {
            OptionAttribute attribute = type.GetCustomAttribute<OptionAttribute>();
            if (attribute == null)
                return;

            services.AddOption(type, configuration.GetSection(attribute.Section));
        }
    }
}
