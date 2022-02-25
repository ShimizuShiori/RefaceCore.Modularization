using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace RefaceCore.Modularization.StartingTools.Enhancers
{
    [StartingTool(typeof(IModuleEnhancer))]
    public class RegsiterServiceDefinedInModule : IModuleEnhancer
    {
        public void Enhance(IServiceCollection services, IModule module)
        {
            Type moduleType = module.GetType();
            foreach (MethodInfo method in moduleType.GetMethods())
            {
                if (method.GetCustomAttribute<ServiceAttribute>() == null)
                    continue;

                Type serviceType = method.ReturnType;

                ServiceLifetimeAttribute serviceLifetimeAttribute = method.GetCustomAttribute<ServiceLifetimeAttribute>();
                if (serviceLifetimeAttribute == null)
                    serviceLifetimeAttribute = new ServiceLifetimeAttribute(ServiceLifetime.Transient);

                ParameterInfo[] parameterInfos = method.GetParameters();

                services.Add(new ServiceDescriptor
                    (
                        serviceType,
                        sp =>
                        {
                            object[] paramters = new object[parameterInfos.Length];

                            for (int i = 0; i < parameterInfos.Length; i++)
                            {
                                paramters[i] = sp.GetService(parameterInfos[i].ParameterType);
                            }

                            return method.Invoke(module, paramters);
                        },
                        serviceLifetimeAttribute.ServiceLifetime
                    ));
            }
        }


    }
}
