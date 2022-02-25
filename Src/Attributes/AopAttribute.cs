using RefaceCore.Modularization.Aop;
using System;

namespace RefaceCore.Modularization.Attributes
{
    /// <summary>
    /// AOP ������
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public abstract class AopAttribute : Attribute
    {
        /// <summary>
        /// ����ִ��ǰ
        /// </summary>
        /// <param name="context"></param>
        public virtual void OnBeforeInvoke(IBeforeInvokeContext context)
        {
        }

        /// <summary>
        /// ����ִ�к�
        /// </summary>
        /// <param name="context"></param>
        public virtual void OnAfterInvoke(IAfterInvokeContext context)
        {

        }

        /// <summary>
        /// ����ִ�й����в����쳣��
        /// </summary>
        /// <param name="context"></param>
        public virtual void OnError(IErrorContext context)
        {
        }

        /// <summary>
        /// ��ִ�н������ <see cref="OnBeforeInvoke(IBeforeInvokeContext)"/> ����ǰ���غ�
        /// </summary>
        /// <param name="context"></param>
        public virtual void OnEarlyReturn(IEarylyReturnContext context) { }
    }
}
