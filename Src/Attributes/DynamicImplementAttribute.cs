using RefaceCore.Modularization.DynamicImplements;
using System;

namespace RefaceCore.Modularization.Attributes
{
    /// <summary>
    /// 动态实现特征
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public abstract class DynamicImplementAttribute : Attribute
    {
        /// <summary>
        /// 当对象上的方法被执行时
        /// </summary>
        /// <param name="context">执行上下文</param>
        /// <returns></returns>
        public abstract void OnInvoke(IDynamicImplementContext context);
    }
}
