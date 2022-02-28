using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Attributes;
using System;

namespace RefaceCore.Modularization.StartingTools.ComponentRegistions
{
    [StartingTool(typeof(IComponentRegistion))]
    public class AutoRegsiterRegistion : IComponentRegistion
    {
        public void OnTypeScanned(IServiceCollection services, Type type)
        {
            AutoRegisterAttribute registerAsAllAttribute = type.GetCustomAttribute<AutoRegisterAttribute>();
            if (registerAsAllAttribute == null)
                return;

            type.GetInterfaces().ForEach(iType =>
            {
                services.Add(new ServiceDescriptor(iType, type, registerAsAllAttribute.ServiceLifetime));
            });
            type.GetAllBaseTypes().ForEach(bType =>
            {
                services.Add(new ServiceDescriptor(bType, type, registerAsAllAttribute.ServiceLifetime));
            });
            services.Add(new ServiceDescriptor(type, type, registerAsAllAttribute.ServiceLifetime));
        }
    }
}
