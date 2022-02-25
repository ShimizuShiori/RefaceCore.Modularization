using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Attributes;
using RefaceCore.Modularization.Helpers;
using RefaceCore.Modularization.Proxies;
using System;
using System.Reflection;

namespace RefaceCore.Modularization.StartingTools.ComponentRegistions
{
    [StartingTool(typeof(IComponentRegistion))]
    public class DynamicImplementRegistion : IComponentRegistion
    {
        public void OnTypeScanned(IServiceCollection services, Type type)
        {
            DynamicImplementAttribute dynamicImplementAttribute = type.GetCustomAttribute<DynamicImplementAttribute>();
            if (dynamicImplementAttribute == null)
                return;

            ServiceLifetimeAttribute serviceLifetimeAttribute = type.GetCustomAttribute<ServiceLifetimeAttribute>();
            if (serviceLifetimeAttribute == null)
                serviceLifetimeAttribute = new ServiceLifetimeAttribute(ServiceLifetime.Transient);

            services.Add(new ServiceDescriptor
                (
                    type,
                    sp =>
                    {
                        sp.InjectProperties(dynamicImplementAttribute);
                        DynamicImplementDispatchProxy dp = DispatchProxyHelper.Create<DynamicImplementDispatchProxy>(type);
                        dp.DynamicImplementAttribute = dynamicImplementAttribute;
                        dp.ServiceProvider = sp;
                        return dp;
                    },
                    serviceLifetimeAttribute.ServiceLifetime
                ));
        }
    }
}
