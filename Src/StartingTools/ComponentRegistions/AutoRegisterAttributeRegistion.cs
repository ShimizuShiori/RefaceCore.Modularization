using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RefaceCore.Modularization.StartingTools.ComponentRegistions
{
    [StartingTool(typeof(IComponentRegistion))]
    public class AutoRegisterAttributeRegistion : IComponentRegistion
    {
        public void OnTypeScanned(IServiceCollection services, Type type)
        {
            IEnumerable<RegisterAsAttribute> attributes = type.GetCustomAttributes<RegisterAsAttribute>();
            if (!attributes.Any())
                return;

            foreach(RegisterAsAttribute attribute in attributes)
                services.Add(new ServiceDescriptor(attribute.ServiceType, type, attribute.ServiceLifetime));

        }
    }
}
