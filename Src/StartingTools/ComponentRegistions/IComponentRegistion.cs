using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Attributes;
using System;

namespace RefaceCore.Modularization.StartingTools.ComponentRegistions
{
    /// <summary>
    /// 组件注册器，该接口用于在 <see cref="ModuleStarter.Start{T}(IServiceCollection, Microsoft.Extensions.Configuration.IConfiguration)"/> 阶段中，
    /// 对组件进行发现与注册。
    /// 
    /// 你需要为你的实现类添加 <see cref="StartingToolAttribute"/> 特征，以便框架能够发现该工具
    /// </summary>
    public interface IComponentRegistion
    {
        /// <summary>
        /// 当类型被扫描到时的回调方法
        /// </summary>
        /// <param name="services">IOC 容器注册器</param>
        /// <param name="type">扫描到的类型</param>
        void OnTypeScanned(IServiceCollection services, Type type);
    }
}
