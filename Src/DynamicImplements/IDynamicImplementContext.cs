using System;
using System.Reflection;

namespace RefaceCore.Modularization.DynamicImplements
{
    /// <summary>
    /// 动态实现器的上下文
    /// </summary>
    public interface IDynamicImplementContext
    {
        /// <summary>
        /// 执行的方法
        /// </summary>
        MethodInfo Method { get; }

        /// <summary>
        /// 执行的参数
        /// </summary>
        object[] Arguments { get; }

        /// <summary>
        /// IOC 容器
        /// </summary>
        IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <param name="result"></param>
        void Return(object result);

    }
}
