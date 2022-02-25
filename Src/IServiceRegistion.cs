using RefaceCore.Modularization.Attributes;
using System;

namespace RefaceCore.Modularization
{
    /// <summary>
    /// 单独的服务注册器，该类型会将 <typeparamref name="TService"/> 注册到 IOC 容器中。
    /// 
    /// 为你的实现类添加 <see cref="ServiceLifetimeAttribute"/> 可以指定注册时的生命周期
    /// </summary>
    /// <typeparam name="TService">注册到 IOC 容器中的类型</typeparam>
    public interface IServiceRegistion<TService>
    {
        /// <summary>
        /// 创建服务的过程
        /// </summary>
        /// <param name="serviceProvider">应用程序的 IOC 容器</param>
        /// <returns></returns>
        TService Create(IServiceProvider serviceProvider);
    }
}
