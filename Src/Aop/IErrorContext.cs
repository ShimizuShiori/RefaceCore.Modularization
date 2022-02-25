using System;

namespace RefaceCore.Modularization.Aop
{
    /// <summary>
    /// �쳣������
    /// </summary>
    public interface IErrorContext : IAopContext
    {
        /// <summary>
        /// ���ص����쳣
        /// </summary>
        Exception Error { get; }

        /// <summary>
        /// ִ�и÷����Ὣ�쳣�����׳�
        /// </summary>
        void Throws();
    }
}
