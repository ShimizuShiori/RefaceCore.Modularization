using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RefaceCore.Modularization.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace RefaceCore.Modularization.StartingTools.ComponentRegistions
{
    [StartingTool(typeof(IComponentRegistion))]
    public class HostedServiceRegistion : IComponentRegistion
    {
        private MethodInfo method;

        public HostedServiceRegistion()
        {
            method = typeof(ServiceCollectionHostedServiceExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(x => x.GetParameters().Length == 1);
        }
        public void OnTypeScanned(IServiceCollection services, Type type)
        {
            if (!typeof(IHostedService).IsAssignableFrom(type))
                return;

            method.MakeGenericMethod(type).Invoke(null, new object[] { services });

        }
    }
}
