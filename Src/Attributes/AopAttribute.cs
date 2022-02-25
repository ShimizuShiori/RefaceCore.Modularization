using RefaceCore.Modularization.Aop;
using System;

namespace RefaceCore.Modularization.Attributes
{
    /// <summary>
    /// AOP 拦截器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public abstract class AopAttribute : Attribute
    {
        /// <summary>
        /// 方法执行前
        /// </summary>
        /// <param name="context"></param>
        public virtual void OnBeforeInvoke(IBeforeInvokeContext context)
        {
        }

        /// <summary>
        /// 方法执行后
        /// </summary>
        /// <param name="context"></param>
        public virtual void OnAfterInvoke(IAfterInvokeContext context)
        {

        }

        /// <summary>
        /// 方法执行过程中产生异常后
        /// </summary>
        /// <param name="context"></param>
        public virtual void OnError(IErrorContext context)
        {
        }

        /// <summary>
        /// 当执行结果是在 <see cref="OnBeforeInvoke(IBeforeInvokeContext)"/> 被提前返回后
        /// </summary>
        /// <param name="context"></param>
        public virtual void OnEarlyReturn(IEarylyReturnContext context) { }
    }
}
