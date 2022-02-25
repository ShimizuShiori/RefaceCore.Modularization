using RefaceCore.Modularization.DynamicImplements;
using System;

namespace RefaceCore.Modularization.Attributes
{
    /// <summary>
    /// ��̬ʵ������
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public abstract class DynamicImplementAttribute : Attribute
    {
        /// <summary>
        /// �������ϵķ�����ִ��ʱ
        /// </summary>
        /// <param name="context">ִ��������</param>
        /// <returns></returns>
        public abstract void OnInvoke(IDynamicImplementContext context);
    }
}
