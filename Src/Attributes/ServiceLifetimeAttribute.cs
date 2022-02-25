using Microsoft.Extensions.DependencyInjection;
using System;

namespace RefaceCore.Modularization.Attributes
{
    /// <summary>
    /// 生命周期
    /// </summary>
    public class ServiceLifetimeAttribute : Attribute
    {
        public ServiceLifetime ServiceLifetime { get; private set; }

        public ServiceLifetimeAttribute(ServiceLifetime serviceLifetime)
        {
            ServiceLifetime = serviceLifetime;
        }
    }
}
