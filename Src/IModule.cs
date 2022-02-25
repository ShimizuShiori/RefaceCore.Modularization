namespace RefaceCore.Modularization
{
    /// <summary>
    /// 模块，模块可以依赖模块，而最终启动项只要启动一个模块即可
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// 当模块被启动时
        /// </summary>
        /// <param name="context"></param>
        void OnStarting(IModuleStartingContext context);

        /// <summary>
        /// 当接受到来自其它模块的消息时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="messageType"></param>
        /// <param name="message"></param>
        void OnReciveMessage(IModule sender, string messageType, object message);
    }
}
