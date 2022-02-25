using RefaceCore.Modularization.Attributes;

namespace RefaceCore.Modularization.Aop
{
    /// <summary>
    /// 当结果被提前返回时的拦截上下文
    /// </summary>
    public interface IEarylyReturnContext : IAopContext
    {
        /// <summary>
        /// 结果
        /// </summary>
        object Result { get; }

        /// <summary>
        /// 提供了该结果的拦截器实例
        /// </summary>
        AopAttribute AopWhichGeneratedThisResult { get; }
    }
}
