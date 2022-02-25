using System;

namespace RefaceCore.Modularization.Aop
{
    /// <summary>
    /// 异常拦截器
    /// </summary>
    public interface IErrorContext : IAopContext
    {
        /// <summary>
        /// 拦截到的异常
        /// </summary>
        Exception Error { get; }

        /// <summary>
        /// 执行该方法会将异常继续抛出
        /// </summary>
        void Throws();
    }
}
