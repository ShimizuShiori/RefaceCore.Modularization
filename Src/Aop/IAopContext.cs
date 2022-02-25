using System;
using System.Reflection;

namespace RefaceCore.Modularization.Aop
{
    /// <summary>
    /// 切面上下文
    /// </summary>
    public interface IAopContext
    {
        /// <summary>
        /// 原始对象，即拦截器所拦截的实例
        /// </summary>
        public object Raw { get; }

        /// <summary>
        /// 拦截到的方法
        /// </summary>
        public MethodInfo Method { get; }

        /// <summary>
        /// 拦截到的参数
        /// </summary>
        public object[] Arguments { get; }

        
        /// <summary>
        /// IOC 组件工厂
        /// </summary>
        public IServiceProvider ServiceProvider { get; }
    }
}
