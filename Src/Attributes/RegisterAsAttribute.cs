using Microsoft.Extensions.DependencyInjection;
using System;

namespace RefaceCore.Modularization.Attributes
{
    /// <summary>
    /// 自动注册
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RegisterAsAttribute : Attribute
    {
        /// <summary>
        /// 注册到哪个类型上
        /// </summary>
        public Type ServiceType { get; private set; }

        /// <summary>
        /// 生命周期
        /// </summary>
        public ServiceLifetime ServiceLifetime { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType">注册到的类型</param>
        /// <param name="serviceLifetime">生命周期</param>
        public RegisterAsAttribute(Type serviceType, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            ServiceType = serviceType;
            ServiceLifetime = serviceLifetime;
        }
    }
}
