using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Attributes;
using System;
using System.Reflection;

namespace RefaceCore.Modularization.StartingTools.ComponentRegistions
{
    [StartingTool(typeof(IComponentRegistion))]
    public class ServiceRegistionRegistion : IComponentRegistion
    {
        private static readonly Type TYPE_IFACTORY = typeof(IServiceRegistion<>);

        public void OnTypeScanned(IServiceCollection services, Type type)
        {
            Type typeInterface = type.GetInterface(TYPE_IFACTORY.FullName);
            if (typeInterface == null)
                return;

            services.Add(new ServiceDescriptor(type, type, ServiceLifetime.Singleton));

            ServiceLifetimeAttribute attribute = type.GetCustomAttribute<ServiceLifetimeAttribute>();
            if (attribute == null)
                attribute = new ServiceLifetimeAttribute(ServiceLifetime.Transient);

            Type serviceType = typeInterface.GetGenericArguments()[0];

            services.Add(new ServiceDescriptor(
                serviceType,
                sp =>
                {
                    object instance = sp.GetService(type);
                    MethodInfo method = type.GetMethod("Create");
                    return method.Invoke(instance, new object[] { sp });
                },
                attribute.ServiceLifetime));
        }
    }
}
