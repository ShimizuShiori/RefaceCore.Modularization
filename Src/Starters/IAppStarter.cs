namespace RefaceCore.Modularization.Starters
{
    /// <summary>
    /// 模块启动器
    /// </summary>
    public interface IAppStarter
    {
        /// <summary>
        /// 启动
        /// </summary>
        void Start<T>() where T : IModule;
    }
}
