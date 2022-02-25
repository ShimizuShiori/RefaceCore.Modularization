using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Attributes;

namespace RefaceCore.Modularization.StartingTools.Enhancers
{
    /// <summary>
    /// 模块增强器，需要通过 <see cref="StartingToolAttribute"/> 特征来声明
    /// </summary>
    public interface IModuleEnhancer
    {
        /// <summary>
        /// 在所有模块都初始化完成后，可以增加所有的模块
        /// </summary>
        /// <param name="services"></param>
        /// <param name="module"></param>
        void Enhance(IServiceCollection services, IModule module);
    }
}
