using System;
using System.Reflection;

namespace RefaceCore.Modularization.Aop
{
    /// <summary>
    /// ����������
    /// </summary>
    public interface IAopContext
    {
        /// <summary>
        /// ԭʼ���󣬼������������ص�ʵ��
        /// </summary>
        public object Raw { get; }

        /// <summary>
        /// ���ص��ķ���
        /// </summary>
        public MethodInfo Method { get; }

        /// <summary>
        /// ���ص��Ĳ���
        /// </summary>
        public object[] Arguments { get; }

        
        /// <summary>
        /// IOC �������
        /// </summary>
        public IServiceProvider ServiceProvider { get; }
    }
}
