using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace RefaceCore.Modularization
{
    /// <summary>
    /// 模块启动上下文
    /// </summary>
    public interface IModuleStartingContext
    {
        /// <summary>
        /// 此次启动所有的 <see cref="IModule"/> 类型（去重）
        /// </summary>
        IEnumerable<Type> ModuleTypes { get; }

        /// <summary>
        /// 所有的模块实例
        /// </summary>
        IEnumerable<IModule> Modules { get; }

        /// <summary>
        /// 此次启动所有 <see cref="IModule"/> 类型所在的程序员（去重）
        /// </summary>
        IEnumerable<Assembly> Assemblies { get; }

        /// <summary>
        /// <see cref="Assemblies"/> 中的所有类型
        /// </summary>
        IEnumerable<Type> AllTypes { get; }

        /// <summary>
        /// 启动工具集合
        /// </summary>
        IServiceProvider StartingToolsContainter { get; }

        /// <summary>
        /// 应用程序的 IOC 容器
        /// </summary>
        IServiceCollection ServiceCollection { get; }


        /// <summary>
        /// 配置
        /// </summary>
        IConfiguration Configuration { get; }

        void PublishMessage(IModule sender, string messageType, object message);
    }
}
