using Microsoft.Extensions.DependencyInjection;
using System;

namespace RefaceCore.Modularization.Attributes
{
    /// <summary>
    /// 自动将组件注册为所有的接口，所有的基类和其自身
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoRegisterAttribute : Attribute
    {
        /// <summary>
        /// 生命周期
        /// </summary>
        public ServiceLifetime ServiceLifetime { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType">注册到的类型</param>
        /// <param name="serviceLifetime">生命周期</param>
        public AutoRegisterAttribute(ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            ServiceLifetime = serviceLifetime;
        }
    }
}
