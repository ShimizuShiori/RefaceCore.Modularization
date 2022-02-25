namespace RefaceCore.Modularization.Aop
{
    /// <summary>
    /// 执行前的拦截上下文
    /// </summary>
    public interface IBeforeInvokeContext : IAopContext
    {
        /// <summary>
        /// 通过该方法可以跳过原本要执行的过程，直接返回结果
        /// </summary>
        /// <param name="result"></param>
        void ReturnValue(object result);
    }
}
