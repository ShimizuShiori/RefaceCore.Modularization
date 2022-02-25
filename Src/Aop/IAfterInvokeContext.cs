namespace RefaceCore.Modularization.Aop
{
    /// <summary>
    /// 执行后的上下文
    /// </summary>
    public interface IAfterInvokeContext : IAopContext
    {
        /// <summary>
        /// 方法执行完成后返回的结果
        /// </summary>
        object Result { get; }
    }
}
